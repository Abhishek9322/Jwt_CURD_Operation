using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_CURD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        [HttpPost("send")]
        [Authorize]
        public IActionResult SendData([FromBody] DataDto data)
        {
            var username = User.Identity.Name;
            return Ok(new

            {
                Message = $"Hello {username}, you submitted: {data.Message}"
            }

                );

        }
    }
    public class DataDto
    {
        public string Message {  get; set; }
    }
}
