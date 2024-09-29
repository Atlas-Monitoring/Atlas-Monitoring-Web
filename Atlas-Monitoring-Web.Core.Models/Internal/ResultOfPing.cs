namespace Atlas_Monitoring_Web.Core.Models.Internal
{
    public class ResultOfPing
    {
        public long ResponseTimeInMS { get; set; }
        public bool PingSucces { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
