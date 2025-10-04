namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class DevicePerformanceDataViewModel
    {
        public Guid Id { get; set; }
        public Guid ComputerId { get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public double ProcessorUtilityPourcent { get; set; } = 0;
        public double MemoryUsed { get; set; } = 0;
        public double UptimeSinceInSecond { get; set; } = 0;
    }
}
