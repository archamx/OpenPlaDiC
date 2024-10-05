using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaDiC.Data;
using PlaDiC.WebPortal.Data;

namespace PlaDiC.WebPortal.Controllers
{
    [Route("apiex/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Identity.Bearer")]
    public class ExtSrvController : ControllerBase
    {

        private readonly PlaDiCDBContext _context;

        public ExtSrvController(PlaDiCDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<string> GetDateTimeServer()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
