using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Application
{
    public interface IDeviceHistoryRepository
    {
        #region Create

        #endregion

        #region Read
        Task<List<DeviceHistoryReadViewModel>> GetHistoryOfADevice(Guid deviceId);
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
