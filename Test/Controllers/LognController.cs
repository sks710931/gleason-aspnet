using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Services;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            this._loginService = loginService;
        }
        
        [HttpPost]
        [Route("login-user")]
        public ActionResult<LoginSuccess> Login([FromBody] LoginRequest user)
        {
            try
            {
                var res = _loginService.Login(user);
                if (res != null)
                {
                    return Ok(new LoginSuccess()
                    {
                        Message = "Login Successful",
                        Status = "200",
                        User = res
                    });
                }
                else
                {
                    return StatusCode(401, new LoginSuccess()
                    {
                        Message = "Login Failed",
                        Status = "401",
                        User = null,
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new LoginSuccess()
                {
                    Message = "Internal Server Error",
                    Status = "500",
                    User = null,
                });
            }
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _loginService.GetAllUsers();
            return users;
        }

        [HttpPost]
        [Route("add-user")]
        public ActionResult<User> AddUser([FromBody] User userToAdd)
        {
            var addedUser = _loginService.AddUser(userToAdd);
            if (addedUser != null)
                return Ok(addedUser);
            else
            {
                return StatusCode(500, null);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<bool> DeleteUser(int id)
        {
            if (_loginService.DeleteUser(id))
            {
                return Ok(true);
            }
            else
            {
               return StatusCode(500, false);
            }
        }
    }


    public class LoginSuccess
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
    }
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
