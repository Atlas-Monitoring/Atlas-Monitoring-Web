using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        #region Properties
        private readonly IComputerDataLayer _computerDataLayer;
        #endregion

        #region Constructor
        public ComputerRepository(IComputerDataLayer computerDataLayer)
        {
            _computerDataLayer = computerDataLayer;
        }        
        #endregion

        #region Public Methods
        #region Read
        public async Task<List<ComputerReadViewModel>> GetAllComputers()
        {
            return await _computerDataLayer.GetAllComputers();
        }

        public async Task<ComputerReadViewModel> GetOneComputer(Guid idComputer)
        {
            return await _computerDataLayer.GetOneComputer(idComputer);
        }
        #endregion

        #region Update
        public async Task UpdateComputerStatus(Guid id, DeviceStatus deviceStatus)
        {
            await _computerDataLayer.UpdateComputerStatus(id, deviceStatus);
        }
        #endregion

        #region Delete
        public async Task DeleteComputer(Guid idComputer)
        {
            await _computerDataLayer.DeleteComputer(idComputer);
        }
        #endregion
        #endregion
    }
}
