using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IComputerPartsDataLayer
    {
        #region Read
        /// <summary>
        /// Get all device part of a computer
        /// </summary>
        /// <param name="computerId">Computer Id</param>
        /// <returns>List of all device part of a computer</returns>
        public Task<List<DevicePartsReadViewModel>> GetAllComputerPartByComputerId(Guid computerId);
        #endregion
    }
}
