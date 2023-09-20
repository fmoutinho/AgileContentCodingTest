using AgileContentCodingTest.Model.Interface;
using System.Text;

namespace AgileContentCodingTest.Model
{
    public class LogFormatter : ILogFormatter
    {
        public string FormatLogs(IEnumerable<LogEntry> logs)
        {
            var output = new StringBuilder();
            output.AppendLine("#Version: 1.0");
            output.AppendLine($"#Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            output.AppendLine("#Fields: provider http-method status-code uri-path time-taken response-size cache-status");

            foreach (var log in logs)
            {
                output.AppendLine(log.ToAgoraFormat());
            }

            return output.ToString();
        }
    }
}
