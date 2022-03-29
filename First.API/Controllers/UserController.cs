using First.API.Models;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace First.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtService jwtService;
        private readonly IUserService userService;

        public UserController(IUserService userService ,IJwtService jwtService)
        {
            this.jwtService=jwtService;
            this.userService = userService;
        }

        [Route("Users")]
        [HttpGet]
        public IActionResult Get()
        {

            var users = userService.GetAllUser().Select(x => new UserDto {
                Name = x.Name,
                Password = x.Password
                
            });
            return Ok();
            //var users = new List<string>
            //{
            //    "John Doe",
            //    "Samet Kayıkcı",
            //    "Bill Gates"
            //};
            //return Ok(users);
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserDto model)
        {
            var token = jwtService.Authenticate(
                new UserDto 
                { 
                    Name = model.Name, 
                    Password = model.Password 
                });


            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
