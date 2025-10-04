using Atlas_Monitoring_Web.Core.Models.Database;
using Atlas_Monitoring_Web.Core.Models.Internal;

namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class DeviceReadViewModel
    {
        public Guid Id { get; set; }
        public DeviceStatus DeviceStatus { get; set; } = DeviceStatus.New;
        public Guid? EntityId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public int DeviceTypeId { get; set; } = DeviceType.Undefined.Id;
        public string DeviceTypeName { get; set; } = DeviceType.Undefined.Name;
        public string Name { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdated { get; set; }



        /// <summary>
        /// Todo : Delete IP
        /// </summary>
        public string Ip { get; set; } = string.Empty;
        /// <summary>
        /// Todo : Delete IP
        /// </summary>
        public string UserName { get; set; } = string.Empty;
    }

    public class DeviceWriteViewModel
    {
        public Guid Id { get; set; }
        public DeviceStatus DeviceStatus { get; set; } = DeviceStatus.New;
        public int DeviceTypeId { get; set; } = DeviceType.Undefined.Id;
        public string Name { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
