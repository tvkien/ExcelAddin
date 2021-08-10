namespace ExcelAddin.Web.Models
{
    public class ApiResource
    {
        public ApiName Name { get; set; }

        public string Uri { get; set; }

        public string TargetClientId { get; set; }

        public string[] Scopes => new string[] { $"{TargetClientId.Trim()}/.default" };
    }
}