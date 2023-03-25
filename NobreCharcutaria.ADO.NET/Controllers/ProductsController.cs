using Microsoft.AspNetCore.Mvc;
using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Services;

namespace NobreCharcutaria.ADO.NET.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public List<Product> Get(string? name)
        {
            ProductService _productService;

            try
            {
                int id = 0;

                _productService = new ProductService();

                return _productService.Select(id, name);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            ProductService _productService;
            Product product;

            try
            {
                _productService = new ProductService();

                string name = null;

                product = _productService.SelectByID(id, name);               

                return product;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            ProductService _productService;
            Product _product;

            try
            {
                _productService = new ProductService();

                _product = _productService.Insert(product);

                return _product;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            ProductService _productService;
            Product _product;

            try
            {
                _productService = new ProductService();

                _product = _productService.Update(product);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _product;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            ProductService _productService;
            bool isDeleted = false;

            try
            {
                _productService = new ProductService();

                isDeleted = _productService.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
