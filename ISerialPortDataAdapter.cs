using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDSerialPort
{
    internal interface ISerialPortDataAdapter
    {
         event Action<int> ReceiveCount;
         event Action<int> SendCount;

        void Config(SerialPortDataAdapterOptions options);

        void Open();

        byte[]? TryPullMessage(int millisecondsToTimeout = -1);

        void Close();

        void Send(byte[] contents, int offset, int length);

        void Send(byte[] contents);

        void Send(string content, Encoding? encoding = null);

        string[] GetAllSerialPort();
        void ClearCount();

    }
}
