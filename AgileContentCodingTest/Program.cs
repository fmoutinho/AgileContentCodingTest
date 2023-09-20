using AgileContentCodingTest.Model;
using System;
using System.IO;
using System.Text;

namespace AgileContentCodingTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: LogConverter <sourceUrl> <targetPath>");
                return;
            }

            var sourceUrl = args[0];
            var targetPath = args[1];

            var logReader = new LogReader();
            var logParser = new LogParser();
            var logFormatter = new LogFormatter();

            var logConverter = new LogConverter(logReader, logParser, logFormatter);

            try
            {
                var convertedLog = logConverter.ConvertLog(sourceUrl);
                File.WriteAllText(targetPath, convertedLog);
                Console.WriteLine($"Log conversion completed. Output saved to {targetPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}