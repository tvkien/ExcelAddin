using System.Threading.Tasks;

namespace ExcelAddin.Web.Interfaces
{
    public interface ITokenManager
    {
        Task<string> AcquireTokenAsync(string[] scopes);
    }
}