using Atlas_Monitoring_Web.Core.Models.Internal;

namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class AutomateLogReadViewModel
    {
        public Guid Id { get; set; }
        public Guid AutomateId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public LogLevel LogLevel { get; set; }
    }

    public class AutomateLogWriteViewModel
    {
        public string Comment { get; set; } = string.Empty;
        public LogLevel LogLevel { get; set; }
    }
}
