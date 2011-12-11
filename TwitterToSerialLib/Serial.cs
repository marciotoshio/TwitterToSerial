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
        string portName;
        int boudRate;

        public Serial(string portName, int boudRate)
        {
            this.portName = portName;
            this.boudRate = boudRate;
            MessageReceived = "";
        }

        public bool IsConnected 
        {
            get 
            { 
                if (serial != null) return serial.IsOpen;
                return false;
            } 
        }

        public void Open()
        {
            serial = new SerialPort(portName, boudRate);
            serial.DataReceived += new SerialDataReceivedEventHandler(Serial_DataReceived);
            serial.Open();
            Write("Hello there.");
        }

        public void Close()
        {
            serial.Close();
        }

        public string MessageReceived
        {
            get;
            private set;
        }
        void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            MessageReceived = serial.ReadLine();
        }

        public void ClearMessage()
        {
            MessageReceived = "";
        }

        public void Write(string message)
        {
            serial.WriteLine(message);
        }
    }
}
