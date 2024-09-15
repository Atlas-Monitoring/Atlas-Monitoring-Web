using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using System.Net;
using System.Net.Http.Json;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class ComputerDataLayer : IComputerDataLayer
    {
        #region Properties
        private readonly string _apiPath = string.Empty;
        #endregion

        #region Constructor
        public ComputerDataLayer()
        {
            _apiPath = "http://localhost:5241/api";
        }
        #endregion

        #region Public Methods
        #region Read
        public async Task<List<ComputerReadViewModel>> GetAllComputers()
        {
            HttpClient client = new HttpClient();
            string path = $"{_apiPath}/Computers/GetAll";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<ComputerReadViewModel> computersList = await response.Content.ReadFromJsonAsync<List<ComputerReadViewModel>>();
                return computersList;
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new();
            }
            else
            {
                throw new CustomDataLayerException($"Response error (Status {response.StatusCode})");
            }
        }

        public async Task<ComputerReadViewModel> GetOneComputer(Guid idComputer)
        {
            HttpClient client = new HttpClient();
            string path = $"{_apiPath}/Computers/{idComputer.ToString()}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ComputerReadViewModel computer = await response.Content.ReadFromJsonAsync<ComputerReadViewModel>();
                return computer;
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new CustomDataLayerException($"No computer found with id '{idComputer.ToString()}'");
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
