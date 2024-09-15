using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using System.Net.Http.Json;
using System.Net;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Microsoft.Extensions.Options;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class ComputerPartsDataLayer : IComputerPartsDataLayer
    {
        #region Properties
        private readonly IOptions<AppConfig> _appConfig;
        #endregion

        #region Constructor
        public ComputerPartsDataLayer(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig;
        }
        #endregion

        #region Publics Methods
        #region Read
        public async Task<List<DevicePartsReadViewModel>> GetAllComputerPartByComputerId(Guid computerId)
        {
            HttpClient client = new HttpClient();
            string path = $"{_appConfig.Value.URLApi}/ComputerParts/{computerId.ToString()}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<DevicePartsReadViewModel> computerParts = await response.Content.ReadFromJsonAsync<List<DevicePartsReadViewModel>>();
                return computerParts;
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new();
            }
            else
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }
        #endregion
        #endregion
    }
}
