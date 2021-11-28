using AutoMapper;
using System.Collections.Generic;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Application.Services
{
    public interface IProductService
    {
        Product CreateProduct(ProductDtoForCreation producto);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
        ProductDtoForDisplay GetProductDtoForDisplayById(int productId);
        List<ProductDtoForDisplay> GetAllProductDtoForDisplay();
        List<ProductDtoForDisplay> GetAllProductDtoForDisplayByCategoryId(int categoryId);
        List<ProductDtoForDisplay> GetAllProductDtoForDisplaysBySupplierId(int supplierId);
        List<ProductDtoForDisplay> GetProductDtoForDisplaysSortedByUnitPrice(string order);
    }
    public class ProductService : IProductService
    {
        private IProductsRepository _repository;

        public ProductService(IProductsRepository repository)
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
                Description = producto.Description,
                Image = producto.Image,
                Url = producto.Url
            };

            _repository.Add(entity);
            return entity;
        }
        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }
        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }
        public ProductDtoForDisplay GetProductDtoForDisplayById(int productId)
        {
            return _repository.GetProductDtoForDisplayById(productId);
        }
        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplay()
        {
            return _repository.GetAllProductDtoForDisplay();
        }
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplayByCategoryId(int categoryId)
        {
            return _repository.GetAllProductDtoForDisplayByCategoryId(categoryId);
        }
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplaysBySupplierId(int supplierId)
        {
            return _repository.GetAllProductDtoForDisplayBySupplierId(supplierId);
        }
        public List<ProductDtoForDisplay> GetProductDtoForDisplaysSortedByUnitPrice(string order)
        {
            return _repository.GetProductDtoForDisplaysSortedByUnitPrice(order);
        }
    }
}
