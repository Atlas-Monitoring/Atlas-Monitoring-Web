using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;
using Atlas_Monitoring_Web.CustomException;
using System.Net.Http.Json;
using System.Net;

namespace Atlas_Monitoring_Web.Core.Infrastructure.DataLayers
{
    public class ComputerDataDataLayer : IComputerDataDataLayer
    {
        #region Properties
        private readonly string _apiPath = string.Empty;
        #endregion

        #region Constructor
        public ComputerDataDataLayer()
        {
            _apiPath = "http://localhost:5241/api";
        }
        #endregion

        #region Public Methods
        #region Create

        #endregion

        #region Read
        public async Task<List<ComputerDataViewModel>> GetAllComputerDataOfAComputer(Guid computerId, DateTime minimumDateDate)
        {
            HttpClient client = new HttpClient();
            string path = $"{_apiPath}/ComputersData/GetByComputerIdAndDate?idComputer={computerId.ToString()}&minimumDataDate={minimumDateDate.ToString("yyyy-MM-dd")}";

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<ComputerDataViewModel> computerData = await response.Content.ReadFromJsonAsync<List<ComputerDataViewModel>>();
                return computerData;
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

        #endregion
        #endregion
    }
}
