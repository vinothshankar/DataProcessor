using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataProcessor.DataSource
{
    public class BinaryDataProcessor : IDataProcessor
    {
        public string ProcessData(string source)
        {
            byte[] byteData = new byte[5];
            using (BinaryReader reader = new BinaryReader(new FileStream(source, FileMode.Open)))
            {
                reader.BaseStream.Seek(5, SeekOrigin.Begin);
                reader.Read(byteData, 0, 5);
            }
            string base64String = Convert.ToBase64String(byteData);
            return base64String;
        }
    }
}
