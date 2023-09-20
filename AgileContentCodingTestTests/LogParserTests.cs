namespace AgileContentCodingTestTests
{
    using AgileContentCodingTest.Model;

    public class LogParserTests
    {

        [Fact]
        public void ParseLogs_ValidLogs_ParsesLogs()
        {
            var logParser = new LogParser();
            var logEntries = File.ReadAllLines("SampleLog.txt");

            var parsedLogs = logParser.ParseLogs(logEntries);


            Assert.Collection(parsedLogs,
                log => Assert.Equal("312", log.ResponseSize),
                log => Assert.Equal("101", log.ResponseSize),
                log => Assert.Equal("199", log.ResponseSize),
                log => Assert.Equal("312", log.ResponseSize)
            );

            Assert.Collection(parsedLogs,
                log => Assert.Equal("MINHA CDN", log.Provider),
                log => Assert.Equal("MINHA CDN", log.Provider),
                log => Assert.Equal("MINHA CDN", log.Provider),
                log => Assert.Equal("MINHA CDN", log.Provider)
            );

            Assert.Collection(parsedLogs,
                log => Assert.Equal("GET", log.HttpMethod),
                log => Assert.Equal("POST", log.HttpMethod),
                log => Assert.Equal("GET", log.HttpMethod),
                log => Assert.Equal("GET", log.HttpMethod)
            );

            Assert.Collection(parsedLogs,
                log => Assert.Equal("200", log.StatusCode),
                log => Assert.Equal("200", log.StatusCode),
                log => Assert.Equal("404", log.StatusCode),
                log => Assert.Equal("200", log.StatusCode)
            );

            Assert.Collection(parsedLogs,
                log => Assert.Equal("/robots.txt", log.UriPath),
                log => Assert.Equal("/myImages", log.UriPath),
                log => Assert.Equal("/not-found", log.UriPath),
                log => Assert.Equal("/robots.txt", log.UriPath)
            );

            Assert.Collection(parsedLogs,
                log => Assert.Equal("100.2", log.TimeTaken),
                log => Assert.Equal("319.4", log.TimeTaken),
                log => Assert.Equal("142.9", log.TimeTaken),
                log => Assert.Equal("245.1", log.TimeTaken)
            );

            Assert.Collection(parsedLogs,
                log => Assert.Equal("HIT", log.CacheStatus),
                log => Assert.Equal("MISS", log.CacheStatus),
                log => Assert.Equal("MISS", log.CacheStatus),
                log => Assert.Equal("REFRESH_HIT", log.CacheStatus)
            );
        }

        [Fact]
        public void ParseLogs_InvalidLogEntry_DoesNotAddToParsedLogs()
        {
            // Arrange
            var logParser = new LogParser();
            var logEntries = new List<string>
            {
                "312|200|HIT|\"GET /robots.txt HTTP/1.1\"", // Missing time-taken field
                "Invalid Log Entry" // Invalid log entry format
            };

            // Act
            var parsedLogs = logParser.ParseLogs(logEntries);

            // Assert
            Assert.NotNull(parsedLogs);
            Assert.Empty(parsedLogs);
        }
    }
}