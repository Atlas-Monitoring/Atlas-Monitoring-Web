namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class DeviceHistoryViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdd { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
