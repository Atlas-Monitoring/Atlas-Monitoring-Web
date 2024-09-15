using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using System.Net.Http.Json;
using System.Net;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Microsoft.Extensions.Options;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class ComputerHardDriveDataLayer : IComputerHardDriveDataLayer
    {
        #region Properties
        private readonly IOptions<AppConfig> _appConfig;
        #endregion

        #region Constructor
        public ComputerHardDriveDataLayer(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig;
        }
        #endregion

        #region Public Methods
        #region Create

        #endregion

        #region Read
        public async Task<List<ComputerHardDriveViewModel>> GetHardDrivesOfAComputer(Guid computerId)
        {
            HttpClient client = new HttpClient();
            string path = $"{_appConfig.Value.URLApi}/ComputersHardDrive/{computerId.ToString()}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<ComputerHardDriveViewModel> computerHardDrives = await response.Content.ReadFromJsonAsync<List<ComputerHardDriveViewModel>>();
                return computerHardDrives;
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new CustomDataLayerException($"No computer found with id '{computerId.ToString()}'");
            }
            else
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
        #endregion
    }
}
