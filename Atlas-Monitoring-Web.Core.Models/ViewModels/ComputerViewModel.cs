using Atlas_Monitoring_Web.Core.Models.Database;

namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class ComputerReadViewModel : DeviceReadViewModel
    {
        public DeviceType DeviceType { get; set; } = DeviceType.Computer;
        public string Ip { get; set; } = string.Empty;
        public double MaxRam { get; set; } = 0;
        public double NumberOfLogicalProcessors { get; set; } = 0;
        public string OS { get; set; } = string.Empty;
        public string OSVersion { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public List<DeviceHardDriveViewModel> ComputerHardDrives { get; set; } = new();
        public List<DevicePerformanceDataViewModel> ComputerLastData { get; set; } = new();
        public List<DeviceHistoryReadViewModel> ComputerHistory { get; set; } = new();
        public List<DevicePartsReadViewModel> ComputerParts { get; set; } = new();
        public List<DeviceSoftwareInstalledReadViewModel> SoftwareInstalled { get; set; } = new();
    }
}
