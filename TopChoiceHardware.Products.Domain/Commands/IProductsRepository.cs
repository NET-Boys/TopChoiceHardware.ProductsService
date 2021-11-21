using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
    }
}
