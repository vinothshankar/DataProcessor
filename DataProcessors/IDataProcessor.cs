using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor.DataSource
{
    interface IDataProcessor
    {
        public string ProcessData(string source);
    }
}
