using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterToSerialLib
{
    public class Helper
    {
        public static string[] Split(string message, int chunkSize)
        {
            int size = message.Length / chunkSize;
            size += message.Length % chunkSize > 0 ? 1 : 0;
            string[] result = new string[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = new string(message.Skip(i * chunkSize).Take(chunkSize).ToArray());
            }
            return result;
        }
    }
}
