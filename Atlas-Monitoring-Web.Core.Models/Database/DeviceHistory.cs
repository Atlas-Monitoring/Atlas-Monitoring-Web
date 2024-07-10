using Atlas_Monitoring.Core.Models.Database;

namespace Atlas_Monitoring_Web.Core.Models.Database
{
    public class DeviceHistory
    {
        public Guid Id { get; set; }
        public Device Device { get; set; }
        public DateTime DateAdd { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
