using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterToSerialLib;

namespace TwitterToSerial
{
    class Program
    {
        private static bool isSending = false;
        static void Main(string[] args)
        {
            var serial = new Serial("COM3", 9600);
            serial.Open();
            
            var twitter = new Twitter();
            var tweets = twitter.GetTweets();

            while (serial.IsConnected)
            {
                if (tweets.Count() == 0)
                {
                    tweets = twitter.GetTweets();
                    continue;
                }
                if (serial.MessageReceived.Contains("close"))
                {
                    serial.Close();
                    serial.ClearMessage();
                }
                if (!isSending)
                {
                    var message = tweets.Last().Text + "\n";
                    var chunks = Helper.Split(message, 64);
                    Send(serial, chunks);
                    tweets = tweets.Take(tweets.Count() - 1);
                }
            }

            Console.WriteLine("Bye.");
            Console.Read();
        }

        private static void Send(Serial serial, string[] chunks)
        {
            isSending = true;
            var i = 0;
            while (isSending)
            {
                serial.Write(chunks[i]);

                while (true)
                {
                    if (serial.MessageReceived.Contains("next chunk"))
                    {
                        i++;
                        serial.ClearMessage();
                        break;
                    }
                    if (serial.MessageReceived.Contains("message received"))
                    {
                        isSending = false;
                        serial.ClearMessage();
                        break;
                    }
                }
                
            }
        }
    }
}
