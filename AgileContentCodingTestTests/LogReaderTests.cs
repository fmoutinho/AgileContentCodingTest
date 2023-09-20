namespace AgileContentCodingTestTests
{
    using AgileContentCodingTest.Model;

    public class LogReaderTests
    {
        [Fact]
        public void ReadLog_ValidSourceUrl_ReturnsLogEntries()
        {
            var logReader = new LogReader();
            var sourceUrl = "SampleLog.txt";

            var logEntries = logReader.ReadLog(sourceUrl);

            Assert.NotNull(logEntries);
            Assert.Equal(4, logEntries.Count());
            Assert.Contains("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2", logEntries);
        }
    }
}