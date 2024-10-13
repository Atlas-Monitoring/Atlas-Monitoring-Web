using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Net;
using System.Net.Http;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class DeviceDataLayer : IDeviceDataLayer
    {
        #region Properties
        private readonly IOptions<AppConfig> _appConfig;
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructor
        public DeviceDataLayer(IOptions<AppConfig> appConfig, HttpClient httpClient)
        {
            _appConfig = appConfig;
            _httpClient = httpClient;
        }
        #endregion

        #region Publics Methods
        #region Create
        public async Task<DeviceReadViewModel> CreateNewDevice(DeviceWriteViewModel newDevice)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Device";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, newDevice);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return await response.Content.ReadFromJsonAsync<DeviceReadViewModel>(); ;
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

        #region Read
        public async Task<List<DeviceReadViewModel>> ListOfDevices()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Device/GetAll";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<List<DeviceReadViewModel>>(); ;
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

        public async Task<List<DeviceReadViewModel>> ListOfDevicesFilteredOnType(int deviceTypeId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Device/GetAllFiltered/{deviceTypeId}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<List<DeviceReadViewModel>>(); ;
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

        public async Task<DeviceReadViewModel> GetOneDevice(Guid deviceId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Device/{deviceId}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DeviceReadViewModel>(); ;
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

        #region Update
        public async Task<DeviceReadViewModel> UpdateDevice(DeviceWriteViewModel updatedDevice)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Device/{updatedDevice.Id}";

            HttpResponseMessage response = await client.PutAsJsonAsync(path, updatedDevice);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DeviceReadViewModel>(); ;
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

        #region Delete
        public async Task<DeviceReadViewModel> DeleteDevice(Guid deviceId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Device/{deviceId}";

            HttpResponseMessage response = await client.DeleteAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<DeviceReadViewModel>(); ;
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
