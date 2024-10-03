using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IComputerDataLayer
    {
        #region Create

        #endregion

        #region Read
        /// <summary>
        /// Get All computers
        /// </summary>
        /// <returns>List of computers</returns>
        Task<List<ComputerReadViewModel>> GetAllComputers();

        /// <summary>
        /// Get one computer
        /// </summary>
        /// <param name="idComputer">Id of the computer</param>
        /// <returns>Object computer</returns>
        Task<ComputerReadViewModel> GetOneComputer(Guid idComputer);
        #endregion

        #region Update

        #endregion

        #region Delete
        /// <summary>
        /// Delete computer
        /// </summary>
        /// <param name="idComputer">Id of computer</param>
        Task DeleteComputer(Guid idComputer);
        #endregion
    }
}
