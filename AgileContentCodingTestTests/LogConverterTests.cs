namespace AgileContentCodingTestTests
{
    using AgileContentCodingTest.Model;
    using AgileContentCodingTest.Model.Interface;
    using Moq;

    public class LogConverterTests
    {
        [Fact]
        public void ConvertLog_ValidInput_ConvertsLogs()
        {
            var logEntries = File.ReadAllLines("SampleLog.txt");

            var logReader = new Mock<ILogReader>();
            var logParser = new Mock<ILogParser>();
            var logFormatter = new Mock<ILogFormatter>();

            logReader.Setup(reader => reader.ReadLog(It.IsAny<string>())).Returns(logEntries);

            logParser.Setup(parser => parser.ParseLogs(It.IsAny<IEnumerable<string>>()))
                .Returns(new List<LogEntry>
            {
                new LogEntry
                {
                    Provider = "MINHA CDN",
                    HttpMethod = "GET",
                    StatusCode = "200",
                    UriPath = "/robots.txt",
                    TimeTaken = "100.2",
                    CacheStatus = "HIT",
                    ResponseSize = "312"
                },
                new LogEntry
                {
                    Provider = "MINHA CDN",
                    HttpMethod = "POST",
                    StatusCode = "200",
                    UriPath = "/myImages",
                    TimeTaken = "319.4",
                    CacheStatus = "MISS",
                    ResponseSize = "101"
                },
                new LogEntry
                {
                    Provider = "MINHA CDN",
                    HttpMethod = "GET",
                    StatusCode = "404",
                    UriPath = "/not-found",
                    TimeTaken = "142.9",
                    CacheStatus = "MISS",
                    ResponseSize = "199"
                },
                new LogEntry
                {
                    Provider = "MINHA CDN",
                    HttpMethod = "GET",
                    StatusCode = "200",
                    UriPath = "/robots.txt",
                    TimeTaken = "245.1",
                    CacheStatus = "REFRESH_HIT",
                    ResponseSize = "312"
                }
            });

            logFormatter.Setup(formatter => formatter.FormatLogs(It.IsAny<IEnumerable<LogEntry>>()))
                    .Returns("#Version: 1.0\r\n#Date: 19/09/2023 19:35:36\r\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\r\nMINHA CDN GET 200 /robots.txt 100.2 312 HIT\r\nMINHA CDN POST 200 /myImages 319.4 101 MISS\r\nMINHA CDN GET 404 /not-found 142.9 199 MISS\r\nMINHA CDN GET 200 /robots.txt 245.1 312 REFRESH_HIT\r\n");

            var logConverter = new LogConverter(logReader.Object, logParser.Object, logFormatter.Object);

            var convertedLog = logConverter.ConvertLog("SampleLog.txt");

            Assert.Contains("#Version: 1.0", convertedLog);
            Assert.Contains("#Date:", convertedLog);
            Assert.Contains("#Fields: provider http-method status-code uri-path time-taken response-size cache-status", convertedLog);
            Assert.Contains("MINHA CDN GET 200 /robots.txt 100.2 312 HIT", convertedLog);
            Assert.Contains("MINHA CDN POST 200 /myImages 319.4 101 MISS", convertedLog);
            Assert.Contains("MINHA CDN GET 404 /not-found 142.9 199 MISS", convertedLog);
            Assert.Contains("MINHA CDN GET 200 /robots.txt 245.1 312 REFRESH_HIT", convertedLog);
        }
    }
}
