using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Repositories;

namespace NobreCharcutaria.ADO.NET.Services
{
    public class UserService
    {
        public List<User> Select(int? id, string? name)
        {
            UserRepository _userRepository;
            List<User> _users;

            try
            {
                _users = new List<User>();

                _userRepository = new UserRepository();

                _users = _userRepository.Select(id, name);

                return _users;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public User SelectByID(int id, string name)
        {
            UserRepository _userRepository;
            User _user;

            try
            {
                _userRepository = new UserRepository();

                var users = _userRepository.Select(id, name);

                _user = new User();
                _user = users.FirstOrDefault();

                return _user;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public User Insert(User user)
        {
            UserRepository _userRepository;
            User _user;

            try
            {
                _userRepository = new UserRepository();

                _user = _userRepository.Insert(user);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _user;
        }

        public User Update(User user)
        {
            UserRepository _userRepository;
            User _user;

            try
            {
                _userRepository = new UserRepository();

                _user = _userRepository.Update(user);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return user;
        }

        public bool Delete(int id)
        {
            UserRepository _userRepository;
            bool isDeleted = false;

            try
            {
                _userRepository = new UserRepository();

                isDeleted = _userRepository.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
