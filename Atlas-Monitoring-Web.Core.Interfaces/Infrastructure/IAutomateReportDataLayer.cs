using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IAutomateReportDataLayer
    {
        #region Create

        #endregion

        #region Read
        /// <summary>
        /// Return the list of report between two date
        /// </summary>
        /// <param name="startDate">Create report start</param>
        /// <param name="endDate">Create report end</param>
        /// <returns>List of Object AutomateReportReadViewModel</returns>
        Task<List<AutomateReportReadViewModel>> GetReportBetweenDate(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Return specific report by it Guid
        /// </summary>
        /// <param name="reportId">Guid of report</param>
        /// <returns>Object AutomateReportReadViewModel</returns>
        Task<AutomateReportReadViewModel> GetOneReportById(Guid reportId);
        #endregion

        #region Update

        #endregion

        #region Delete
        /// <summary>
        /// Delete one report
        /// </summary>
        /// <param name="reportId">Delete one report by it Guid</param>
        Task DeleteOneReportById(Guid reportId);
        #endregion
    }
}
