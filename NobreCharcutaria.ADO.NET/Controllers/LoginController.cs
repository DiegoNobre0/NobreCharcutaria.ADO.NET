using Microsoft.AspNetCore.Mvc;
using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Services;

namespace NobreCharcutaria.ADO.NET.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Login([FromBody] Login login)
        {
            LoginService _loginService;
            TokenService _tokenService;

            try
            {
                _loginService = new LoginService();

                var _users = _loginService.Select(login);

                _tokenService = new TokenService();

                string _token = _tokenService.GenerateToken(_users);

                var token = new { token = _token };

                return Ok(token);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
    }
}
