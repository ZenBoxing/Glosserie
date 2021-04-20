using Glosserie.API.Data;
using Glosserie.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGlosserieRepo _repo;

        public UserController(IGlosserieRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("login")]
        public ActionResult<UserModel> Login(LoginModel loginModel)
        {
            var user = _repo.Login(loginModel.Email,loginModel.Password);
            if (user.Email == "failed" || user.Email == "UserDoesNotExist")
            {
                return BadRequest();
            }
            else 
            {
                return Ok(user);
            }
        }
        //maybe return registration result  
        [HttpPost("register")]
        public ActionResult<bool> Register(RegistrationModel info)
        {
            
            var success = _repo.Register(info.Email, info.Password, info.ConfirmPassword);
            if (success == false)
            {
                return BadRequest();
            }
            else 
            {
                return Ok(success);
            }
        }
    }
}
