using DataProcessor.DataSource;
using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataProcessor
{
    public class DataProcessorControllerMain
    {
        static void Main(string[] args)
        {
            DataProcessorService dataProcessorController = new DataProcessorService();
            if (args.Length == 2)
            {
                string filePath = args[0];
                string dataType = args[1];

                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    if (dataProcessorController.ValidateDataType(dataType))
                    {
                        dataProcessorController.StartDataProcess(filePath, dataType);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Data Type");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid File Path");
                }
            }
            else
            {
                Console.WriteLine("Invalid number of arguments");
            }
            Console.WriteLine("Press any key to quit !!");
            Console.ReadKey();
        }
    }
}
