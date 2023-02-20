using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDSerialPort
{
    /// <summary>
    /// 串口信息事件
    /// </summary>
    internal class SerialPortMessageEventArgs: EventArgs
    {
        public byte[] Data { get; private set; }

        public SerialPortMessageEventArgs(byte[] data)
        {
            this.Data = data;
        }
    }
}
