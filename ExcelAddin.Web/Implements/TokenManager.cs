using ExcelAddin.Web.Interfaces;
using ExcelAddin.Web.Models;
using Microsoft.Identity.Client;
using System.Threading.Tasks;

namespace ExcelAddin.Web.Implements
{
    public class TokenManager : ITokenManager
    {
        private readonly AzureAdSetting azureAdSetting;

        public TokenManager(AzureAdSetting azureAdSetting)
            => this.azureAdSetting = azureAdSetting;

        public async Task<string> AcquireTokenAsync(string[] scopes)
        {
            var app = ConfidentialClientApplicationBuilder
                .Create(azureAdSetting.ClientId)
                .WithTenantId(azureAdSetting.TenantId)
                .WithClientSecret(azureAdSetting.ClientSecret)
                .Build();

            var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
            return result.AccessToken;
        }
    }
}