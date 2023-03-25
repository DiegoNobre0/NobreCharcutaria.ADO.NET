using Microsoft.AspNetCore.Mvc;
using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Services;

namespace NobreCharcutaria.ADO.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerTypesController : Controller
    {
        [HttpGet]
        public List<CustomerType> Get(string? type)
        {
            CustomerTypeService _customerTypeService;

            try
            {
                int id = 0;

                _customerTypeService = new CustomerTypeService();

                return _customerTypeService.Select(id, type);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpGet("{id}")]
        public CustomerType GetById(int id)
        {
            CustomerTypeService _customerTypeService;
            CustomerType customerType;

            try
            {
                _customerTypeService = new CustomerTypeService();

                string type = null;

                customerType = _customerTypeService.SelectByID(id, type);

                return customerType;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPost]
        public CustomerType Post(CustomerType customerType)
        {
            CustomerTypeService _customerTypeService;
            CustomerType _customerType;

            try
            {
                _customerTypeService = new CustomerTypeService();

                _customerType = _customerTypeService.Insert(customerType);

                return _customerType;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPut("{id}")]
        public CustomerType Put(int id, [FromBody] CustomerType customerType)
        {
            CustomerTypeService _customerTypeService;
            CustomerType _customerType;

            try
            {
                _customerTypeService = new CustomerTypeService();

                _customerType = _customerTypeService.Update(customerType);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _customerType;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            CustomerTypeService _customerTypeService;
            bool isDeleted = false;

            try
            {
                _customerTypeService = new CustomerTypeService();

                isDeleted = _customerTypeService.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
