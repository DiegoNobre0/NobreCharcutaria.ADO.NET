using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Repositories;

namespace NobreCharcutaria.ADO.NET.Services
{
    public class CustomerTypeService
    {
        public List<CustomerType> Select(int? id, string? type)
        {
            CustomerTypeRepository _customerTypeRepository;
            List<CustomerType> _customerTypes;

            try
            {
                _customerTypes = new List<CustomerType>();

                _customerTypeRepository = new CustomerTypeRepository();

                _customerTypes = _customerTypeRepository.Select(id, type);

                return _customerTypes;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public CustomerType SelectByID(int id, string type)
        {
            CustomerTypeRepository _customerTypeRepository;
            CustomerType _customerType;

            try
            {
                _customerTypeRepository = new CustomerTypeRepository();

                var users = _customerTypeRepository.Select(id, type);

                _customerType = new CustomerType();
                _customerType = users.FirstOrDefault();
                
                return _customerType;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public CustomerType Insert(CustomerType customerType)
        {
            CustomerTypeRepository _customerTypeRepository;
            CustomerType _customerType;

            try
            {
                _customerTypeRepository = new CustomerTypeRepository();

                _customerType = _customerTypeRepository.Insert(customerType);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _customerType;
        }

        public CustomerType Update(CustomerType customerType)
        {
            CustomerTypeRepository _customerTypeRepository;
            CustomerType _customerType;

            try
            {
                _customerTypeRepository = new CustomerTypeRepository();

                _customerType = _customerTypeRepository.Update(customerType);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customerType;
        }

        public bool Delete(int id)
        {
            CustomerTypeRepository _customerTypeRepository;
            bool isDeleted = false;

            try
            {
                _customerTypeRepository = new CustomerTypeRepository();

                isDeleted = _customerTypeRepository.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
