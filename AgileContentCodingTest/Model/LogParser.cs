using AgileContentCodingTest.Model.Interface;

namespace AgileContentCodingTest.Model
{
    public class LogParser : ILogParser
    {
        public IEnumerable<LogEntry> ParseLogs(IEnumerable<string> logEntries)
        {
            var parsedLogs = new List<LogEntry>();

            foreach (var logEntry in logEntries)
            {
                var parts = logEntry.Split('|');
                if (parts.Length == 5)
                {
                    var cacheStatus = parts[2];
                    string translatedCacheStatus;

                    switch (cacheStatus)
                    {
                        case "HIT":
                            translatedCacheStatus = "HIT";
                            break;
                        case "INVALIDATE":
                            translatedCacheStatus = "REFRESH_HIT";
                            break;
                        default:
                            translatedCacheStatus = "MISS";
                            break;
                    }

                    var log = new LogEntry
                    {
                        Provider = "MINHA CDN",
                        HttpMethod = parts[3].Trim('"').Split(' ')[0],
                        StatusCode = parts[1],
                        UriPath = parts[3].Trim('"').Split(' ')[1],
                        TimeTaken = parts[4],
                        ResponseSize = parts[0],
                        CacheStatus = translatedCacheStatus
                    };
                    parsedLogs.Add(log);
                }
            }

            return parsedLogs;
        }
    }
}
