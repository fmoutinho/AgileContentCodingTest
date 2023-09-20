namespace AgileContentCodingTest.Model.Interface
{
    public interface ILogFormatter
    {
        string FormatLogs(IEnumerable<LogEntry> logs);
    }
}
