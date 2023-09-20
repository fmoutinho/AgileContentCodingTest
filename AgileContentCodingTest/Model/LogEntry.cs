namespace AgileContentCodingTest.Model
{
    public class LogEntry
    {
        public string? Provider { get; set; }
        public string? HttpMethod { get; set; }
        public string? StatusCode { get; set; }
        public string? UriPath { get; set; }
        public string? TimeTaken { get; set; }
        public string? ResponseSize { get; set; }
        public string? CacheStatus { get; set; }

        public string ToAgoraFormat()
        {
            return $"{Provider} {HttpMethod} {StatusCode} {UriPath} {TimeTaken} {ResponseSize} {CacheStatus}";
        }
    }
}
