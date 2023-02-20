using Microsoft.VisualBasic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace LEDSerialPort
{
    internal class SerialPortDataAdapter: ISerialPortDataAdapter
    {
        //事件处理
        public event Action<int> ReceiveCount;
        public event Action<int> SendCount;
        private readonly EventWaitHandle _messageWaitHandle;  //线程
        private readonly ConcurrentQueue<byte[]> _messageQueue;   //消息队列
        private SerialPort _serialPort;
        private const int _baudRate = 9600;
        private const int _dataBits = 8;
        private const Parity _parity = Parity.None;
        private const StopBits _stopBits = StopBits.One;
        private const int _readTimeout = 500;
        private const int _writeTimeout = 500;
        private readonly object _mux;
        private int _receiveCount, _sendCount;

        public SerialPortDataAdapter()
        {
            _mux = new object();
            _receiveCount = 0;
            _sendCount = 0;
            _messageQueue = new ConcurrentQueue<byte[]>();
            _messageWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        }

        public void Config(SerialPortDataAdapterOptions options)
        {
            if (options == null) throw new ArgumentNullException("options");
            if (string.IsNullOrEmpty(options.PortName)) throw new ArgumentNullException("options.SerialPort");

            _serialPort = new SerialPort(options.PortName);
            _serialPort.BaudRate = options.BaudRate > 0 ? options.BaudRate : _baudRate;
            _serialPort.Parity = options.Parity ?? _parity;
            _serialPort.DataBits = options.DataBits > 0 ? options.DataBits : _dataBits;
            _serialPort.StopBits = options.StopBits ?? _stopBits;
            _serialPort.ReadTimeout = options.ReadTimeout > 0 ? options.ReadTimeout : _readTimeout;
            _serialPort.WriteTimeout = options.WriteTimeout > 0 ? options.WriteTimeout : _writeTimeout;
        }

        public void Open()
        {

            // 设置读/写缓冲区大小，默认值为1MB
            _serialPort.ReadBufferSize = 1024 * 1024;
            _serialPort.WriteBufferSize = 1024 * 1024;

            _serialPort.Open();

            //清空缓存区
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();

            Console.WriteLine($"串口是否开启:{_serialPort.IsOpen}，端口名称:{_serialPort.PortName}");

            //开启
            PushMessage();

            Console.WriteLine($"端口名称:{_serialPort.PortName}，消息监听开始");
        }


        /// <summary>
        /// 监听消息把消息加入到队列
        /// </summary>
        private void PushMessage()
        {
            _serialPort.DataReceived += (sender, e) =>
            {
                lock (_mux)
                {
                    if (_serialPort.IsOpen == false) return;
                    int length = _serialPort.BytesToRead;
                    byte[] buffer = new byte[length];
                    _serialPort.Read(buffer, 0, length);
                    _receiveCount += length;
                    ReceiveCount?.Invoke(_receiveCount);
                    _messageQueue.Enqueue(buffer);
                    _messageWaitHandle.Set();
                }
            };
        }

        /// <summary>
        /// 拉取串口接受到的内容
        /// </summary>
        /// <param name="millisecondsToTimeout">取消息的超时时间</param>
        /// <returns>返回byte数组</returns>
        public byte[]? TryPullMessage(int millisecondsToTimeout = -1)
        {
            if (_messageQueue.TryDequeue(out var message))
            {
                return message;
            }

            if (_messageWaitHandle.WaitOne(millisecondsToTimeout))
            {
                if (_messageQueue.TryDequeue(out message))
                {
                    return message;
                }
            }
            return null;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        public void Send(string content, Encoding? encoding=null)
        {
            lock (_mux)
            {
                encoding ??= Encoding.ASCII;
                var buffer = encoding.GetBytes(content);
                _serialPort.Write(buffer, 0, buffer.Length);
                _sendCount += buffer.Length;
                SendCount?.Invoke(_sendCount);
            }
           
        }

        /// <summary>
        /// 发送消息（byte数组）
        /// </summary>
        /// <param name="contents"></param>
        public void Send(byte[] contents)
        {
            lock (_mux)
            {
                _serialPort.Write(contents, 0, contents.Length);
                _sendCount += contents.Length;
                SendCount?.Invoke(_sendCount);
            }
        }

        /// <summary>
        /// 发送消息（byte数组）
        /// </summary>
        /// <param name="contents"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Send(byte[] contents, int offset, int length)
        {
            if (_serialPort == null) throw new ArgumentNullException("_serialPort");
            if (!_serialPort.IsOpen) throw new ArgumentNullException("_serialPort is Closed");
            lock (_mux)
            {
                _serialPort.Write(contents, offset, length);
                _sendCount += (length - offset);
                SendCount?.Invoke(_sendCount);
            }
           
        }

        public void Close()
        {
            _serialPort.Close();
            ClearCount();
            Console.WriteLine($"串口是否开启:{_serialPort.IsOpen}，端口名称:{_serialPort.PortName}");
        }

        /// <summary>
        /// 获取所有的串口
        /// </summary>
        /// <returns></returns>
        public string[] GetAllSerialPort()
        {
          return  SerialPort.GetPortNames();
        }

        /// <summary>
        /// 清空接受/发送总数统计
        /// </summary>
        public void ClearCount()
        {
            lock (_mux)
            {
                _sendCount = 0;
                _receiveCount = 0;
                ReceiveCount?.Invoke(_sendCount);
                SendCount?.Invoke(_sendCount);
            }
        }

    }
}
