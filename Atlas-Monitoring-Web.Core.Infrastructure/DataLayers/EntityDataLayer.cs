using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Net;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class EntityDataLayer : IEntityDataLayer
    {
        #region Properties
        private readonly IOptions<AppConfig> _appConfig;
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructor
        public EntityDataLayer(IOptions<AppConfig> appConfig, HttpClient httpClient)
        {
            _appConfig = appConfig;
            _httpClient = httpClient;
        }
        #endregion

        #region Publics Methods
        #region Create
        public async Task<EntityReadViewModel> CreateNewEntity(EntityWriteViewModel entityWriteViewModel)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Entity";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, entityWriteViewModel);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                EntityReadViewModel entityReadView = await response.Content.ReadFromJsonAsync<EntityReadViewModel>();
                return entityReadView;
            }
            else
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }
        #endregion

        #region Read
        public async Task<List<EntityReadViewModel>> GetListOfEntity()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Entity";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<EntityReadViewModel> listOfEntityReadView = await response.Content.ReadFromJsonAsync<List<EntityReadViewModel>>();
                return listOfEntityReadView;
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

        #endregion

        #region Delete
        public async Task DeleteOneEntity(Guid entityId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/Entity/{entityId}";

            HttpResponseMessage response = await client.DeleteAsync(path);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }
        #endregion
        #endregion
    }
}
