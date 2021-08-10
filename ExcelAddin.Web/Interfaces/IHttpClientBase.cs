using System.Net.Http;
using System.Threading.Tasks;

namespace ExcelAddin.Web.Interfaces
{
    public interface IHttpClientBase
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}