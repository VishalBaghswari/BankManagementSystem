using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Models;
using BankManagementSystem.Service;

namespace BankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UsersController));
        private readonly IUserService _Service;
        public UsersController(IUserService Service)
        {
            _Service = Service;
        }

        // GET: 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            _log4net.Info("User ID " + id + " Entered For Searching");
            _log4net.Info("Calling GetUser method of service from controller");
            var user =await _Service.GetUser(id);

            if (user == null)
            {
                _log4net.Info("User Not found");
                return NotFound();
            }
            _log4net.Info("User Returned");
            return Ok(user);
        }

        // PUT: 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id,[FromBody] User user)
        {
            _log4net.Info("User ID " + id + " Entered For Updating user details");
            
            if (id != user.UserId)
            {
                _log4net.Info("Update failed");
                return BadRequest();
            }
            else
            {
                _log4net.Info("Calling UpdateUser method of service from controller");
                string status =await _Service.UpdateUser(id,user);
                _log4net.Info("Update successful");
                return Ok(status);
            }
        }

        // POST: 
        [HttpPost("Signin")]
        public async Task<IActionResult> SignIn([FromBody] UserLogin credential)
        {
            string username = credential.UserName;
            string password = credential.Password;
            _log4net.Info("UserName " + username +" and Password " + password+ " Entered For Authentication");
            if (username == null || password == null)
            {
                _log4net.Info("Login failed");
                return BadRequest("Invalid Username or Password");
            }
            _log4net.Info("Calling AuthenticateMember method of service from controller");
            User user =await _Service.AuthenticateMember(username, password);
            _log4net.Info("Login successful");

            return Ok(user);
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            _log4net.Info("Entered For Registration");
            if (user == null)
            {
                _log4net.Info("Registration failed");
                return BadRequest("Please Provide Data");
            }
            else
            {
                _log4net.Info("Calling AddUser method of service from controller");
                string status = await _Service.AddUser(user);
                _log4net.Info("Registration successful");
                return Ok(status);
            }

        }

        
    }
}
