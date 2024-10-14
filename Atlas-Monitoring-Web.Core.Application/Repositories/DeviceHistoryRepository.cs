using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class DeviceHistoryRepository : IDeviceHistoryRepository
    {
        #region Properties
        private readonly IDeviceHistoryDataLayer _deviceHistoryDataLayer;
        #endregion

        #region Constructor
        public DeviceHistoryRepository(IDeviceHistoryDataLayer deviceHistoryDataLayer)
        {
            _deviceHistoryDataLayer = deviceHistoryDataLayer;
        }
        #endregion

        #region Publics Methods
        #region Read
        public async Task<List<DeviceHistoryReadViewModel>> GetHistoryOfADevice(Guid deviceId)
        {
            return await _deviceHistoryDataLayer.GetHistoryOfADevice(deviceId);
        }
        #endregion
        #endregion
    }
}
