using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IDeviceDataLayer
    {
        #region Create
        #endregion

        #region Read
        /// <summary>
        /// Get the list of the devices
        /// </summary>
        /// <returns>List of Object DeviceReadViewModel</returns>
        public Task<List<DeviceReadViewModel>> ListOfDevices();

        /// <summary>
        /// Get the list of the devices filtered on type
        /// </summary>
        /// <param name="deviceTypeId">Id of device type</param>
        /// <returns>List of Object DeviceReadViewModel</returns>
        public Task<List<DeviceReadViewModel>> ListOfDevicesFilteredOnType(int deviceTypeId);

        /// <summary>
        /// Get one device by GUID
        /// </summary>
        /// <returns>List of Object DeviceReadViewModel</returns>
        public Task<DeviceReadViewModel> GetOneDevice(Guid deviceId);
        #endregion

        #region Update
        /// <summary>
        /// Update device
        /// </summary>
        /// <param name="updatedDevice">Object DeviceWriteViewModel</param>
        /// <returns>Object DeviceReadViewModel</returns>
        public Task<DeviceReadViewModel> UpdateDevice(DeviceWriteViewModel updatedDevice);

        /// <summary>
        /// Update status of a device
        /// </summary>
        /// <param name="id">Id of device</param>
        /// <param name="deviceStatus">Status of the device</param>
        public Task UpdateDeviceStatus(Guid id, DeviceStatus deviceStatus);

        /// <summary>
        /// Update entity of device
        /// </summary>
        /// <param name="deviceId">Id of device</param>
        /// <param name="entityId">Id of entity</param>
        public Task UpdateDeviceEntity(Guid deviceId, Guid entityId);
        #endregion

        #region Delete
        /// <summary>
        /// Update device
        /// </summary>
        /// <param name="deviceId">GUID of the device</param>
        /// <returns>List of Object DeviceViewModel</returns>
        public Task<DeviceReadViewModel> DeleteDevice(Guid deviceId);
        #endregion
    }
}
