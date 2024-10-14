using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Net;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class DeviceHistoryDataLayer : IDeviceHistoryDataLayer
    {
        #region Properties
        private readonly IOptions<AppConfig> _appConfig;
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructor
        public DeviceHistoryDataLayer(IOptions<AppConfig> appConfig, HttpClient httpClient)
        {
            _appConfig = appConfig;
            _httpClient = httpClient;
        }
        #endregion

        #region Publics Methods
        #region Read
        public async Task<List<DeviceHistoryReadViewModel>> GetHistoryOfADevice(Guid deviceId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/DeviceHistory/{deviceId.ToString()}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<DeviceHistoryReadViewModel> deviceHistory = await response.Content.ReadFromJsonAsync<List<DeviceHistoryReadViewModel>>();
                return deviceHistory;
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
