using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
        List<ProductDtoForDisplay> GetProductDtoForDisplaysSortedByUnitPrice(string order);
        List<ProductDtoForDisplay> ApplyLikeParameterToList(string likeParameter, List<ProductDtoForDisplay> productDtoList);

        List<ProductDtoForDisplay> SortListOfProductsDto(string order, List<ProductDtoForDisplay> productDtoList);

        StockResponse ReduceStock(List<ProductStockDto> orden);
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
        public List<ProductDtoForDisplay> GetProductDtoForDisplaysSortedByUnitPrice(string order)
        {
            return _repository.GetProductDtoForDisplaysSortedByUnitPrice(order);
        }
        public List<ProductDtoForDisplay> ApplyLikeParameterToList(string likeParameter, List<ProductDtoForDisplay> productDtoList)
        {
            return _repository.ApplyLikeParameterToList(likeParameter, productDtoList);
        }
        public List<ProductDtoForDisplay> SortListOfProductsDto(string order, List<ProductDtoForDisplay> productDtoList)
        {
            return _repository.SortListOfProductsDto(order, productDtoList);
        }

        public StockResponse ReduceStock(List<ProductStockDto> orden)
        {
            var allProductos = new List<Product>();

            foreach(var producto in _repository.GetAllProducts())
            {
                foreach(var dto in orden)
                {
                    if(producto.ProductId == dto.ProductId)
                    {
                        allProductos.Add(producto);
                    }
                }
            }

            foreach(var producto in allProductos)
            {
                foreach(var dto in orden)
                {
                    if(producto.UnitsInStock < dto.Cantidad)
                    {
                        var response = new StockResponse
                        {
                            Message = "No se puede completar la orden, no se dispone de stock",
                            Status = "Fail"
                        };

                        return response;
                    }
                }
            }

            foreach(var item in orden)
            {
                var producto = GetProductById(item.ProductId);
                producto.UnitsInStock -= item.Cantidad;
                _repository.ReducirStock(producto);
            }

            var respuesta = new StockResponse
            {
                Message = "Se completó la transacción exitosamente",
                Status = "Success"
            };

            return respuesta;
        }
    }
}
