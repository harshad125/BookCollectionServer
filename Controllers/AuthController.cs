using Microsoft.AspNetCore.Mvc;
using MyCollection.Data;
using MyCollection.Models;

namespace MyCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepo _authRepo;

        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<int>> Register(UserRegisterDTO userDTO)
        {
            var res = await _authRepo.Register(new User() { User_Name = userDTO.User_Name, Email = userDTO.Email, Mobile = userDTO.Mobile }, userDTO.Password);
            if (res == 0)
            {
                return BadRequest($"cannot register {userDTO.User_Name}");
            }
            return Ok($"User Account Created Successfully!");
        }

        [HttpPost("Login")]
        public async Task<ActionResult<int>> Login(UserLoginDTO userDTO)
        {
            var res = await _authRepo.Login(userDTO.Email, userDTO.Password);
            if (res == null)
            {
                return BadRequest($"Incorrect Email or Password1");
            }
            return Ok(res);
        }
    }
}
