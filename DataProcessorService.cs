using DataProcessor.DataSource;
using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor
{
    public class DataProcessorService
    {
        IDataProcessor _dataProcessor;

        public bool ValidateDataType(string dataType)
        {
            List<string> validDataTypes = new List<string>()
            {
                AppConstants.DataTypeBinary,
                AppConstants.DataTypeText,
                AppConstants.DataTypeTextReverse
            };
            if (validDataTypes.Contains(dataType))
            {
                return true;
            }
            return false;
        }
        public void StartDataProcess(string filePath, string dataType)
        {
            switch (dataType)
            {
                case AppConstants.DataTypeBinary:
                    _dataProcessor = new BinaryDataProcessor();
                    string responseBase64 = _dataProcessor.ProcessData(filePath);
                    Console.WriteLine("Base 64 String : " + responseBase64);
                    break;
                case AppConstants.DataTypeText:
                    _dataProcessor = new TextDataProcessor();
                    string responseStringUft8 = _dataProcessor.ProcessData(filePath);
                    Console.WriteLine("Textual data in UTF8 format: " + responseStringUft8);
                    break;
                case AppConstants.DataTypeTextReverse:
                    _dataProcessor = new TextReverseDataProcessor();
                    string responseStringReverseUft8 = _dataProcessor.ProcessData(filePath);
                    Console.WriteLine("Textual data in reverse order in UTF8 format: " + responseStringReverseUft8);
                    break;
            }
        }
    }
}
