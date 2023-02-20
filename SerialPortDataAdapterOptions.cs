using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDSerialPort
{
    /// <summary>
    /// 串口基础信息
    /// </summary>
    internal class SerialPortDataAdapterOptions
    {
        /// <summary>
        /// 串口
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// 串行波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 奇偶校验检查协议
        /// </summary>
        public Parity? Parity { get; set; }

        /// <summary>
        /// 每个字节的标准数据位长度
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// 每个字节的标准停止位数
        /// </summary>
        public StopBits? StopBits { get; set; }

        /// <summary>
        /// 读操作的超时时间(毫秒数)
        /// </summary>
        public int ReadTimeout { get; set; }

        /// <summary>
        /// 写操作的超时时间(毫秒数)
        /// </summary>
        public int WriteTimeout { get; set; }
    }
}
