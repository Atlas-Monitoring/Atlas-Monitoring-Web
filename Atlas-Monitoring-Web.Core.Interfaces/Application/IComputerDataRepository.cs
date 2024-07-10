using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Application
{
    public interface IComputerDataRepository
    {
        #region Create

        #endregion

        #region Read
        /// <summary>
        /// Get All Computer Data of a Computer
        /// </summary>
        /// <param name="computerId">Id of computer</param>
        /// <param name="minimumDateDate">Minimum Date of Data</param>
        /// <returns>List of Computer Data</returns>
        Task<List<ComputerDataViewModel>> GetAllComputerDataOfAComputer(Guid computerId, DateTime minimumDateDate);
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
