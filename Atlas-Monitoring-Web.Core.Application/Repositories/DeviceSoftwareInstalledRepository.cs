using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class DeviceSoftwareInstalledRepository : IDeviceSoftwareInstalledRepository
    {
        #region Properties
        private readonly IDeviceSoftwareInstalledDataLayer _deviceSoftwareInstalledDataLayer;
        #endregion

        #region Constructor
        public DeviceSoftwareInstalledRepository(IDeviceSoftwareInstalledDataLayer deviceSoftwareInstalledDataLayer)
        {
            _deviceSoftwareInstalledDataLayer = deviceSoftwareInstalledDataLayer;
        }
        #endregion

        #region Public Methods
        #region Read
        public Task<List<DeviceSoftwareInstalledReadViewModel>> ListOfSoftwareOnDevice(Guid deviceId)
        {
            return _deviceSoftwareInstalledDataLayer.ListOfSoftwareOnDevice(deviceId);
        }
        #endregion
        #endregion
    }
}
