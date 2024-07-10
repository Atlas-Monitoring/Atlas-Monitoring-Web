using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IComputerHardDriveDataLayer
    {
        #region Create

        #endregion

        #region Read
        /// <summary>
        /// Get all Hard Drives of a computer
        /// </summary>
        /// <param name="computerId">Computer Id</param>
        /// <returns>List of Hard drive</returns>
        Task<List<ComputerHardDriveViewModel>> GetHardDrivesOfAComputer(Guid computerId);
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
