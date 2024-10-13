using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Application
{
    public interface IComputerRepository
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
        /// <summary>
        /// Update status of computer
        /// </summary>
        /// <param name="id">Id of computer</param>
        /// <param name="deviceStatus">Status of the device</param>
        public Task UpdateComputerStatus(Guid id, DeviceStatus deviceStatus);

        /// <summary>
        /// Update entity of computer
        /// </summary>
        /// <param name="computerId">Id of computer</param>
        /// <param name="entityId">Id of entity</param>
        public Task UpdateComputerEntity(Guid computerId, Guid entityId);
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
