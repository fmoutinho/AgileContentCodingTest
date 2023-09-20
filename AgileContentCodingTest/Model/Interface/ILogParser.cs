namespace AgileContentCodingTest.Model.Interface
{
    public interface ILogParser
    {
        IEnumerable<LogEntry> ParseLogs(IEnumerable<string> logEntries);
    }
}
