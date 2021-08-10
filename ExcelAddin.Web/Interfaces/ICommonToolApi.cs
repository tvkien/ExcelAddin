using ExcelAddin.Web.Models;
using System.Threading.Tasks;

namespace ExcelAddin.Web.Interfaces
{
    public interface ICommonToolApi
    {
        Task<bool> CreateCommentAsync(CreateCommentRequest request);
    }
}