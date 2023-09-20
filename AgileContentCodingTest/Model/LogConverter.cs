using AgileContentCodingTest.Model.Interface;

namespace AgileContentCodingTest.Model
{
    public class LogConverter : ILogConverter
    {
        private readonly ILogReader _logReader;
        private readonly ILogParser _logParser;
        private readonly ILogFormatter _logFormatter;

        public LogConverter(ILogReader logReader, ILogParser logParser, ILogFormatter logFormatter)
        {
            _logReader = logReader;
            _logParser = logParser;
            _logFormatter = logFormatter;
        }

        public string ConvertLog(string sourceUrl)
        {
            var logEntries = _logReader.ReadLog(sourceUrl);
            var convertedLogs = _logParser.ParseLogs(logEntries);
            var formattedLog = _logFormatter.FormatLogs(convertedLogs);

            return formattedLog;
        }
    }
}
