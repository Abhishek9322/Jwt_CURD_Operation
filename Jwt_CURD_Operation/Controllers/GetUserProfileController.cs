using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Jwt_CURD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserProfileController : ControllerBase
    {
        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetUerProfile()
        {
            var userName = User.Identity.Name; //built in claim
            var userType = User.FindFirst("UserType")?.Value;
            var email = User.FindFirst("Email")?.Value;
            var adress = User.FindFirst("Address")?.Value;
         //   var ImgURL = User.FindFirst("imgcat2Url")?.Value;

            return Ok(new
            {
                userName,
                userType,
                email,
                adress,
             //   ImgURL


            });


        }

        //[HttpGet("upload-profile-image")]
        //public async Task<ActionResult> uploadProdfileImage(UserLogin user)
        //{
        //    return Ok();
        //}

    }
}
