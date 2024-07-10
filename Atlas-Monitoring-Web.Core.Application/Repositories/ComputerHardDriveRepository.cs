using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class ComputerHardDriveRepository : IComputerHardDriveRepository
    {
        #region Properties
        private readonly IComputerHardDriveDataLayer _computerHardDriveDataLayer;
        #endregion

        #region Constructor
        public ComputerHardDriveRepository(IComputerHardDriveDataLayer computerHardDriveDataLayer)
        {
            _computerHardDriveDataLayer = computerHardDriveDataLayer;
        }
        #endregion

        #region Public Methods
        #region Create

        #endregion

        #region Read
        public async Task<List<ComputerHardDriveViewModel>> GetHardDrivesOfAComputer(Guid computerId)
        {
            return await _computerHardDriveDataLayer.GetHardDrivesOfAComputer(computerId);
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
        #endregion

    }
}
