using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LuftBornTask.Domain.Entities;
using LuftBornTask.Services.Dto;
using System.Text;
using Microsoft.AspNetCore.Http;
using LuftBornTask.Services.IServices;
using LuftBornTask.API.jwt;
using Microsoft.Extensions.Configuration;

namespace LuftBornTask.Api.Controllers
{
    [Route("/api/account")]
    public class AccountController : MainController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly JwtFactory _jwt;
        private readonly IUnitOfWork _context;
        private readonly IConfiguration _config;

        public AccountController(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor accessor, JwtFactory jwtFactory, IUnitOfWork context,IConfiguration config)
        {
            _userManager = userManager;
            _accessor = accessor;
            _jwt = jwtFactory;
            _context = context;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<object> UserLogin(AccountDto login)
        {
            var key = Encoding.UTF8.GetBytes(_config["JWTSettings:SecretKey"].ToString());
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var empId = _context.EmployeeService.GetEmployeeByLoggedInUser(user.Id).EmployeeId;

                var token = _jwt.GenerateToken(key, user, userRoles, empId);
                //add token to cookies
                _accessor.HttpContext.Response.Cookies.Append("token",token);
                //return Ok(token);
                return Ok();
            }
            else
                return BadRequest(new { errorMessage = "Email or password is not valid"});
        }

        [HttpPost("register")]
        public async Task<object> UserRegister(AccountDto register)
        {
            var user = new ApplicationUser()
            {
                UserName = register.Email,
                Email = register.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(user, register.Password);
                await _userManager.AddToRoleAsync(user, "User");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ex.InnerException.Message;
            }
        }
    }
}
