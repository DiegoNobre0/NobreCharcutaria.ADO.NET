using NobreCharcutaria.ADO.NET.Models;
using NobreCharcutaria.ADO.NET.Repositories;

namespace NobreCharcutaria.ADO.NET.Services
{
    public class ProductService
    {
        public List<Product> Select(int? id, string? name)
        {
            ProductRepository _productRepository;
            List<Product> _products;

            try
            {
                _products = new List<Product>();

                _productRepository = new ProductRepository();

                _products = _productRepository.Select(id, name);

                return _products;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public Product SelectByID(int id, string name)
        {
            ProductRepository _productRepository;
            Product _product;

            try
            {
                _productRepository = new ProductRepository();

                var products = _productRepository.Select(id, name);

                _product = new Product();
                _product = products.FirstOrDefault();

                return _product;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public Product Insert(Product product)
        {
            ProductRepository _productRepository;
            Product _product;

            try
            {
                _productRepository = new ProductRepository();

                _product = _productRepository.Insert(product);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return _product;
        }

        public Product Update(Product product)
        {
            ProductRepository _productRepository;
            Product _product;

            try
            {
                _productRepository = new ProductRepository();

                _product = _productRepository.Update(product);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return product;
        }

        public bool Delete(int id)
        {
            ProductRepository _productRepository;
            bool isDeleted = false;

            try
            {
                _productRepository = new ProductRepository();

                isDeleted = _productRepository.Delete(id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

            return isDeleted;
        }
    }
}
