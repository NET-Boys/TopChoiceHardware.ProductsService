﻿using AutoMapper;
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
    }
    public class ProductService : IProductService
    {
        private IProductsRepository _repository;
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductsRepository repository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
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

    }
}