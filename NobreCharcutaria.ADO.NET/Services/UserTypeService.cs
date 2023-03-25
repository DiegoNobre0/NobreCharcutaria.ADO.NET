using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Repositories;

namespace NobreCharcutaria.ADO.NET.Services
{
    public class UserTypeService
    {
        public List<UserType> Select(int? id, string? type)
        {
            UserTypeRepository _userTypeRepository;
            List<UserType> _userTypes;

            try
            {
                _userTypes = new List<UserType>();

                _userTypeRepository = new UserTypeRepository();

                _userTypes = _userTypeRepository.Select(id, type);

                return _userTypes;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public UserType SelectByID(int id, string type)
        {
            UserTypeRepository _userTypeRepository;
            UserType _userType;

            try
            {
                _userTypeRepository = new UserTypeRepository();

                var users = _userTypeRepository.Select(id, type);

                _userType = new UserType();
                _userType = users.FirstOrDefault();

                return _userType;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public UserType Insert(UserType userType)
        {
            UserTypeRepository _userTypeRepository;
            UserType _userType;

            try
            {
                _userTypeRepository = new UserTypeRepository();

                _userType = _userTypeRepository.Insert(userType);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _userType;
        }

        public UserType Update(UserType userType)
        {
            UserTypeRepository _userTypeRepository;
            UserType _userType;

            try
            {
                _userTypeRepository = new UserTypeRepository();

                _userType = _userTypeRepository.Update(userType);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return userType;
        }

        public bool Delete(int id)
        {
            UserTypeRepository _userTypeRepository;
            bool isDeleted = false;

            try
            {
                _userTypeRepository = new UserTypeRepository();

                isDeleted = _userTypeRepository.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
