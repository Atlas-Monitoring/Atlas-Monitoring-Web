using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
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
        public async Task<DeviceReadViewModel> CreateNewDevice(DeviceWriteViewModel newDevice)
        {
            return await _deviceDataLayer.CreateNewDevice(newDevice);
        }
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
