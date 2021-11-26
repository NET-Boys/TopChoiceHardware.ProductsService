using System.Collections.Generic;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Domain.Commands
{
    public interface IProductsRepository
    {
        void Add(Product products);
        Product GetProductById(int id);
        ProductDtoForDisplay GetProductDtoForDisplayById(int productId);
        List<Product> GetAllProducts();
        List<ProductDtoForDisplay> GetAllProductDtoForDisplay();
        void Update(Product product);
        void Delete(Product product);
        void DeleteById(int id);
        List<ProductDtoForDisplay> GetAllProductDtoForDisplayByCategoryId(int categoryId);
        List<ProductDtoForDisplay> GetAllProductDtoForDisplayBySupplierId(int supplierId);
        List<ProductDtoForDisplay> GetProductDtoForDisplaysSortedByUnitPrice(string order);
    }
}
