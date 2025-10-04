using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        #region Properties
        private readonly IDeviceDataLayer _deviceDataLayer;
        #endregion

        #region Constructor
        public DeviceRepository(IDeviceDataLayer deviceDataLayer)
        {
            _deviceDataLayer = deviceDataLayer;
        }
        #endregion

        #region Publics Methods
        #region Create
        #endregion

        #region Read
        public async Task<List<DeviceReadViewModel>> ListOfDevices()
        {
            return await _deviceDataLayer.ListOfDevices();
        }

        public async Task<List<DeviceReadViewModel>> ListOfDevicesFilteredOnType(int deviceTypeId)
        {
            return await _deviceDataLayer.ListOfDevicesFilteredOnType(deviceTypeId);
        }

        public async Task<DeviceReadViewModel> GetOneDevice(Guid deviceId)
        {
            return await _deviceDataLayer.GetOneDevice(deviceId);
        }
        #endregion

        #region Update
        public async Task<DeviceReadViewModel> UpdateDevice(DeviceWriteViewModel updatedDevice)
        {
            return await _deviceDataLayer.UpdateDevice(updatedDevice);
        }

        public async Task UpdateDeviceStatus(Guid id, DeviceStatus deviceStatus)
        {
            await _deviceDataLayer.UpdateDeviceStatus(id, deviceStatus);
        }

        public async Task UpdateDeviceEntity(Guid deviceId, Guid entityId)
        {
            await _deviceDataLayer.UpdateDeviceEntity(deviceId, entityId);
        }
        #endregion

        #region Delete
        public async Task<DeviceReadViewModel> DeleteDevice(Guid deviceId)
        {
            return await _deviceDataLayer.DeleteDevice(deviceId);
        }
        #endregion
        #endregion
    }
}
