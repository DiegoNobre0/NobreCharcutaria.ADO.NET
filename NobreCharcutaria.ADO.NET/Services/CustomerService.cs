using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Repositories;

namespace NobreCharcutaria.ADO.NET.Services
{
    public class CustomerService
    {
        public List<Customer> Select(int? id, string? cliente)
        {
            CustomerRepository _customerRepository;
            List<Customer> _customers;

            try
            {
                _customers = new List<Customer>();

                _customerRepository = new CustomerRepository();

                _customers = _customerRepository.Select(id, cliente);

                return _customers;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public Customer SelectByID(int id, string cliente)
        {
            CustomerRepository _customerRepository;
            Customer _customer;

            try
            {
                _customerRepository = new CustomerRepository();

                var users = _customerRepository.Select(id, cliente);

                _customer = new Customer();
                _customer = users.FirstOrDefault();

                return _customer;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public Customer Insert(Customer customer)
        {
            CustomerRepository _customerRepository;
            Customer _customer;

            try
            {
                _customerRepository = new CustomerRepository();

                _customer = _customerRepository.Insert(customer);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _customer;
        }

        public Customer Update(Customer customer)
        {
            CustomerRepository _customerRepository;
            Customer _customer;

            try
            {
                _customerRepository = new CustomerRepository();

                _customer = _customerRepository.Update(customer);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return customer;
        }

        public bool Delete(int id)
        {
            CustomerRepository _customerRepository;
            bool isDeleted = false;

            try
            {
                _customerRepository = new CustomerRepository();

                isDeleted = _customerRepository.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
