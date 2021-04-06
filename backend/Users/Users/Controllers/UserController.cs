using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.UsersData;

namespace Users.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserData _UserData;
        public UserController(IUserData userData)
        {
            _UserData = userData;
        }

        [HttpGet]
        [Route("api/[controller]/getUsers")]
        public IActionResult getUsers()
        {
            return Ok(_UserData.getUsers());
        }

        [HttpGet]
        [Route("api/[controller]/getUser/{id}")]
        public IActionResult getUser(string User_id)
        {
            var user = _UserData.GetUser(User_id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound($"User with id: {User_id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]/AddUser")]
        public IActionResult AddUser(User user)
        {
            _UserData.AddUser(user);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + user.User_ID,
                user);
        }


        [HttpDelete]
        [Route("api/[controller]/DeleteUser/{id}")]
        public IActionResult DeleteUser(string user_id)
        {
            var user = _UserData.GetUser(user_id);

            if (user != null)
            {
                _UserData.DeleteUser(user);
                return Ok();
            }

            return NotFound($"User with id: {user_id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/EditUser/{id}")]
        public IActionResult EditUser(string user_id, User user)
        {
            var ExistingUser = _UserData.GetUser(user_id);

            if (ExistingUser != null)
            {
                user.User_ID = ExistingUser.User_ID;
                _UserData.EditUser(ExistingUser);
                return Ok();
            }

            return Ok(ExistingUser);
        }
    }
}