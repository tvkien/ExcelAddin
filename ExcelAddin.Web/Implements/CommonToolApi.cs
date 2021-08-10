using ExcelAddin.Web.Interfaces;
using ExcelAddin.Web.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAddin.Web.Implements
{
    public class CommonToolApi : ICommonToolApi
    {
        private readonly IHttpClientBase httpClientBase;
        private readonly AzureAdSetting azureAdSetting;
        private readonly ITokenManager tokenManager;

        public CommonToolApi(
            IHttpClientBase httpClientBase,
            AzureAdSetting azureAdSetting,
            ITokenManager tokenManager)
        {
            this.httpClientBase = httpClientBase;
            this.azureAdSetting = azureAdSetting;
            this.tokenManager = tokenManager;
        }

        public async Task<bool> CreateCommentAsync(CreateCommentRequest request)
        {
            var apiResource = azureAdSetting.ApiResources.FirstOrDefault(x => x.Name == ApiName.CORE);
            var accessToken = await tokenManager.AcquireTokenAsync(apiResource.Scopes);
            var httpRequest = new HttpRequestMessage
            {
                RequestUri = new Uri($"{apiResource.Uri}api/ExcelAddin/createReviewNote"),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpRequest.Headers.Add("containerCode", "AAAAAA");
            var response = await httpClientBase.SendAsync(httpRequest);

            return response.IsSuccessStatusCode;
        }
    }
}
