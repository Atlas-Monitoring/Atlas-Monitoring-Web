using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class ComputerPartsRepository : IComputerPartsRepository
    {
        #region Properties
        private readonly IComputerPartsDataLayer _computerPartsDataLayer;
        #endregion

        #region Constructor
        public ComputerPartsRepository(IComputerPartsDataLayer computerPartsDataLayer)
        {
            _computerPartsDataLayer = computerPartsDataLayer;
        }
        #endregion

        #region Publics Methods
        #region Read
        public async Task<List<DevicePartsReadViewModel>> GetAllComputerPartByComputerId(Guid computerId)
        {
            return await _computerPartsDataLayer.GetAllComputerPartByComputerId(computerId);
        }
        #endregion
        #endregion


    }
}
