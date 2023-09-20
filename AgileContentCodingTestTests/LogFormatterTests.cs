namespace AgileContentCodingTestTests
{
    using AgileContentCodingTest.Model;
    using AgileContentCodingTest.Model.Interface;
    using Moq;

    public class LogFormatterTests
    {
        [Fact]
        public void FormatLogs_ValidLogs_FormatsLogs()
        {
            var logs = new List<LogEntry>
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
            };

            var logFormatter = new LogFormatter();

            var formattedLog = logFormatter.FormatLogs(logs);

            // Assert
            Assert.Contains("#Version: 1.0", formattedLog);
            Assert.Contains("#Date:", formattedLog);
            Assert.Contains("#Fields: provider http-method status-code uri-path time-taken response-size cache-status", formattedLog);
            Assert.Contains("MINHA CDN GET 200 /robots.txt 100.2 312 HIT", formattedLog);
            Assert.Contains("MINHA CDN POST 200 /myImages 319.4 101 MISS", formattedLog);
            Assert.Contains("MINHA CDN GET 404 /not-found 142.9 199 MISS", formattedLog);
            Assert.Contains("MINHA CDN GET 200 /robots.txt 245.1 312 REFRESH_HIT", formattedLog);

        }
    }
}