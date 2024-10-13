using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.Internal;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Net;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class UserDataLayer : IUserDataLayer
    {
        #region Properties
        private readonly IOptions<AppConfig> _appConfig;
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructor
        public UserDataLayer(IOptions<AppConfig> appConfig, HttpClient httpClient)
        {
            _appConfig = appConfig;
            _httpClient = httpClient;
        }
        #endregion

        #region Publics Methods
        #region Create

        #endregion

        #region Read
        public async Task<string> AuthUser(AuthUserViewModel authUserViewModel)
        {
            HttpClient client = new HttpClient();
            string path = $"{_appConfig.Value.URLApi}/User/Auth";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, authUserViewModel);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync(); ;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new CustomMessageException("Msg_Authentification_Failed");
            }
            else
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }
        #endregion

        #region Update
        public async Task UpdatePassword(AuthUserViewModel authUserViewModel)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = _httpClient.DefaultRequestHeaders.Authorization;
            string path = $"{_appConfig.Value.URLApi}/User/UpdatePassword";

            HttpResponseMessage response = await client.PutAsJsonAsync(path, authUserViewModel);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new CustomMessageException("Msg_Authentification_Failed");
            }
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }
        #endregion

        #region Delete

        #endregion
        #endregion
    }
}
