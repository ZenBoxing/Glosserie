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

        [HttpGet]
        public ActionResult<UserModel> GetUser(string email, string password)
        {
            var user = _repo.Login(email,password);
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
        [HttpPost]
        public ActionResult<bool> PostUser(RegistrationModel info)
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
