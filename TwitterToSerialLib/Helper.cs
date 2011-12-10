using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterToSerialLib
{
    public class Helper
    {
        public static string[] Split(string message, int bufferSize)
        {
            int size = message.Length / bufferSize;
            size += message.Length % bufferSize > 0 ? 1 : 0;
            string[] result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = new string(message.Skip(i * bufferSize).Take(bufferSize).ToArray());
            }
            return result;
        }
    }
}
