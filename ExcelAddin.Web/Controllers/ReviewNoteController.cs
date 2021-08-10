using ExcelAddin.Web.Interfaces;
using ExcelAddin.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExcelAddin.Web.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ReviewNoteController : Controller
    {
        private readonly ILogger<ReviewNoteController> _logger;
        private readonly ICommonToolApi commonToolApi;

        public ReviewNoteController(
            ILogger<ReviewNoteController> logger,
            ICommonToolApi commonToolApi)
        {
            _logger = logger;
            this.commonToolApi = commonToolApi;
        }

        [HttpPost("addReviewNote")]
        public async Task<JsonResult> AddReviewNote([FromBody] CreateCommentRequest request)
        {
            var response = await commonToolApi.CreateCommentAsync(request);
            return Json(response);
        }
    }
}