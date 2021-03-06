using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataProcessor.DataSource
{
    public class TextDataProcessor : IDataProcessor
    {
        public string ProcessData(string source)
        {
            int charCount = 5;
            using (var stream = File.OpenRead(source))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                char[] buffer = new char[charCount];
                int n = reader.ReadBlock(buffer, 0, charCount);
                char[] result = new char[n];
                Array.Copy(buffer, result, n);
                string str = new string(result);
                byte[] bytes = Encoding.Default.GetBytes(str);
                str = Encoding.UTF8.GetString(bytes);
                return str;
            }
        }
    }
}
