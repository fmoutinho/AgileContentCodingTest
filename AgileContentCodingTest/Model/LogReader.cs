using AgileContentCodingTest.Model.Interface;

namespace AgileContentCodingTest.Model
{
    public class LogReader : ILogReader
    {
        public IEnumerable<string> ReadLog(string sourceUrl)
        {
            return File.ReadAllLines(sourceUrl).ToList();
        }
    }
}
