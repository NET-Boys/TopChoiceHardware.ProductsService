using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.Entities;
using TopChoiceHardware.Products.Domain.DTOs;
using AutoMapper;

namespace TopChoiceHardware.Products.AccessData.Commands
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _context;
        private ICategoryRepository _categoryRepository;
        private ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public ProductsRepository(ProductsContext context, IMapper mapper, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository)
        {
            _context = context;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        } 
        public Product GetProductById(int id)
        {
            return _context.Product.SingleOrDefault(Product => Product.ProductId == id);
        }
        public ProductDtoForDisplay GetProductDtoForDisplayById(int productId)
        {
            var product = GetProductById(productId);
            if(product != null)
            {
                var productMapped = _mapper.Map<ProductDtoForDisplay>(product);
                //CategoryID y SupplierID ahora son strings 
                productMapped.CategoryName = _categoryRepository.GetCategoryById(product.CategoryId).CategoryName;
                productMapped.SupplierName = _supplierRepository.GetSupplierById(product.SupplierId).CompanyName;
                return productMapped;
            }

            return null;
            
        }
        public List<Product> GetAllProducts()
        {
            return _context.Product.ToList();
        }
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplay()
        {
            var listproductDtoForDisplays= new List<ProductDtoForDisplay>();
            foreach (var product in GetAllProducts())
            {
                listproductDtoForDisplays.Add(GetProductDtoForDisplayById(product.ProductId));
            }
            return listproductDtoForDisplays;
        }
        public void Update(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
       
        public void DeleteById(int id)
        {
            var product = GetProductById(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}
