﻿using Atlas_Monitoring_Web.Core.Models.Database;
using Atlas_Monitoring_Web.Core.Models.Internal;

namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class ComputerReadViewModel
    {
        public Guid Id { get; set; }
        public DeviceStatus DeviceStatus { get; set; } = DeviceStatus.New;
        public DeviceType DeviceType { get; set; } = DeviceType.Computer;
        public string Name { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public double MaxRam { get; set; } = 0;
        public double NumberOfLogicalProcessors { get; set; } = 0;
        public string OS { get; set; } = string.Empty;
        public string OSVersion { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdated { get; set; }

        public List<ComputerHardDriveViewModel> ComputerHardDrives = new();
        public List<ComputerDataViewModel> ComputerLastData = new();
        public List<DeviceHistoryViewModel> ComputerHistory = new();
        public List<DevicePartsReadViewModel> ComputerParts = new();
    }

    public class ComputerWriteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public double MaxRam { get; set; } = 0;
        public double NumberOfLogicalProcessors { get; set; } = 0;
        public string OS { get; set; } = string.Empty;
        public string OSVersion { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
