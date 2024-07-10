using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class ComputerDataRepository : IComputerDataRepository
    {
        #region Properties
        private readonly IComputerDataDataLayer _computerDataDataLayer;
        #endregion

        #region Constructor
        public ComputerDataRepository(IComputerDataDataLayer computerDataDataLayer)
        {
            _computerDataDataLayer = computerDataDataLayer;
        }
        #endregion

        #region Public Methods
        #region Create

        #endregion

        #region Read
        public async Task<List<ComputerDataViewModel>> GetAllComputerDataOfAComputer(Guid computerId, DateTime minimumDateDate)
        {
            return await _computerDataDataLayer.GetAllComputerDataOfAComputer(computerId, minimumDateDate);
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
        #endregion
    }
}
