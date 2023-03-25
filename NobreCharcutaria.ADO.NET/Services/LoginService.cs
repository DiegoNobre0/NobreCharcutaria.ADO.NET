using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Repositories;

namespace NobreCharcutaria.ADO.NET.Services
{
    public class LoginService
    {
        public User Select(Login login)
        {
            LoginRepository _loginRepository;
            List<User> _users;

            try
            {
                _users = new List<User>();

                _loginRepository = new LoginRepository();

                _users = _loginRepository.Select(login);
                
                var user = _users.FirstOrDefault();

                return user;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
    }
}
