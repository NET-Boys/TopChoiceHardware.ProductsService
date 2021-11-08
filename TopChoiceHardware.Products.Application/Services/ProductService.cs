using System.Collections.Generic;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Application.Services
{
    public interface IProductService
    {
        Product CreateProduct(ProductDtoForCreation producto);
        List<Product> GetProductos();
        Product GetProductoById(int id);
        void UpdateProduct(Product product);
    }
    public class ProductService : IProductService
    {
        private IGenericRepository _repository;

        public ProductService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Product CreateProduct(ProductDtoForCreation producto)
        {
            var entity = new Product
            {
                ProductName = producto.ProductName,
                CategoryId = producto.CategoryId,
                SupplierId = producto.SupplierId,
                UnitPrice = producto.UnitPrice,
                UnitsInStock = producto.UnitsInStock,
                Brand = producto.Brand,
                Description = producto.Description
            };
            
            _repository.Add(entity);
            return entity;
        }
        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }

        public Product GetProductoById(int id)
        {
            return _repository.GetById<Product>(id);
        }

        public List<Product> GetProductos()
        {
            return _repository.GetAll<Product>();
        }
    }
}
