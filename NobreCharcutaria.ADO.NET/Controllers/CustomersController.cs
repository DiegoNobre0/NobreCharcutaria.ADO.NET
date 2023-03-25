using Microsoft.AspNetCore.Mvc;
using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Services;

namespace NobreCharcutaria.ADO.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : Controller
    {
        [HttpGet]
        public List<Customer> Get(string? cliente)
        {
            CustomerService _customerService;

            try
            {
                int id = 0;

                _customerService = new CustomerService();

                return _customerService.Select(id, cliente);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            CustomerService _customerService;
            Customer customer;

            try
            {
                _customerService = new CustomerService();

                string cliente = null;

                customer = _customerService.SelectByID(id, cliente);

                return customer;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPost]
        public Customer Post(Customer customer)
        {
            CustomerService _customerService;
            Customer _customer;

            try
            {
                _customerService = new CustomerService();

                _customer = _customerService.Insert(customer);

                return _customer;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPut("{id}")]
        public Customer Put(int id, [FromBody] Customer customer)
        {
            CustomerService _customerService;
            Customer _customer;

            try
            {
                _customerService = new CustomerService();

                _customer = _customerService.Update(customer);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _customer;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            CustomerService _customerService;
            bool isDeleted = false;

            try
            {
                _customerService = new CustomerService();

                isDeleted = _customerService.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
