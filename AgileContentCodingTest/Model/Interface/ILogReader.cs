namespace AgileContentCodingTest.Model.Interface
{
    public interface ILogReader
    {
        IEnumerable<string> ReadLog(string sourceUrl);
    }
}
