using System.Collections.Generic;

namespace ExcelAddin.Web.Models
{
    public class AzureAdSetting
    {
        public string Instance { get; set; }

        public string TenantId { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public List<ApiResource> ApiResources { get; set; }
    }
}