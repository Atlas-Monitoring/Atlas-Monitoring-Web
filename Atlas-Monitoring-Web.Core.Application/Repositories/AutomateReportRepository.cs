using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class AutomateReportRepository : IAutomateReportRepository
    {
        #region Properties
        private readonly IAutomateReportDataLayer _automateReportDataLayer;
        #endregion

        #region Constructor
        public AutomateReportRepository(IAutomateReportDataLayer automateReportDataLayer)
        {
            _automateReportDataLayer = automateReportDataLayer;
        }
        #endregion

        #region Public Methods
        #region Create
        public async Task CreateNewReport(AutomateReportWriteViewModel newReport)
        {
            await _automateReportDataLayer.CreateNewReport(newReport);
        }
        #endregion

        #region Read
        public async Task<AutomateReportReadViewModel> GetOneReportById(Guid reportId)
        {
            return await _automateReportDataLayer.GetOneReportById(reportId);
        }

        public async Task<List<AutomateReportReadViewModel>> GetReportBetweenDate(DateTime startDate, DateTime endDate)
        {
            return await _automateReportDataLayer.GetReportBetweenDate(startDate, endDate);
        }
        #endregion

        #region Update

        #endregion

        #region Delete
        public async Task DeleteOneReportById(Guid reportId)
        {
            await _automateReportDataLayer.DeleteOneReportById(reportId);
        }
        #endregion
        #endregion
    }
}
