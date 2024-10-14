using Atlas_Monitoring_Web.Core.Models.Internal;

namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class DeviceHistoryReadViewModel
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime DateAdd { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class DeviceHistoryWriteViewModel
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public DateTime DateAdd { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
