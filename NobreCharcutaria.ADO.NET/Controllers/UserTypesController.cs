using Microsoft.AspNetCore.Mvc;
using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Services;

namespace NobreCharcutaria.ADO.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserTypesController : Controller
    {
        [HttpGet]
        public List<UserType> Get(string? type)
        {
            UserTypeService _userTypeService;

            try
            {
                int id = 0;

                _userTypeService = new UserTypeService();

                return _userTypeService.Select(id, type);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpGet("{id}")]
        public UserType GetById(int id)
        {
            UserTypeService _userTypeService;
            UserType userType;

            try
            {
                _userTypeService = new UserTypeService();

                string type = null;

                userType = _userTypeService.SelectByID(id, type);

                return userType;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPost]
        public UserType Post(UserType userType)
        {
            UserTypeService _userTypeService;
            UserType _userType;

            try
            {
                _userTypeService = new UserTypeService();

                _userType = _userTypeService.Insert(userType);

                return _userType;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPut("{id}")]
        public UserType Put(int id, [FromBody] UserType userType)
        {
            UserTypeService _userTypeService;
            UserType _userType;

            try
            {
                _userTypeService = new UserTypeService();

                _userType = _userTypeService.Update(userType);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _userType;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            UserTypeService _userTypeService;
            bool isDeleted = false;

            try
            {
                _userTypeService = new UserTypeService();

                isDeleted = _userTypeService.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
