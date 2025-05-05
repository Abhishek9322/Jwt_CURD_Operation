using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_CURD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userAccessController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { Message = "Authorize User Can access" });
        }

    }
}
