using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TwitterToSerialLib
{
    public class Serial
    {
        private SerialPort serial;
        public void Open(string portName, int boudRate)
        {
            serial = new SerialPort(portName, boudRate);
            Write("Connected.");
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }
    }
}
