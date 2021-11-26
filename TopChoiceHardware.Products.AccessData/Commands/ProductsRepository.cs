using System.Collections.Generic;
using System.Linq;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.Entities;
using TopChoiceHardware.Products.Domain.DTOs;
using AutoMapper;

namespace TopChoiceHardware.Products.AccessData.Commands
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
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

        public List<string> GetCarouselOfProductsByProductId(int productId)
        {
            var images = _context.Image.Where(Image => Image.ProductId == productId);
            var Carousel = new List<string>();
            foreach (var image in images)
            {
                Carousel.Add(image.Url);
            }
            return Carousel;
        }
        public ProductDtoForDisplay GetProductDtoForDisplayById(int productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                var productMapped = _mapper.Map<ProductDtoForDisplay>(product);
                //CategoryID y SupplierID ahora son strings 
                productMapped.CategoryName = _categoryRepository.GetCategoryById(product.CategoryId).CategoryName;
                productMapped.SupplierName = _supplierRepository.GetSupplierById(product.SupplierId).CompanyName;
                productMapped.Carousel = GetCarouselOfProductsByProductId(productId);
                return productMapped;
            }
            return null;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Product.ToList();
        }
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplay() //Para el getall
        {
            var listproductDtoForDisplays = new List<ProductDtoForDisplay>();
            foreach (var product in GetAllProducts())
            {
                listproductDtoForDisplays.Add(GetProductDtoForDisplayById(product.ProductId));
            }
            return listproductDtoForDisplays;
        }
        public List<ProductDtoForDisplay> GetProductDtoForDisplaysSortedByUnitPrice(string order)
        {
            var listproductDtoForDisplays = new List<ProductDtoForDisplay>();
            if (order == "ASC")
            {
                listproductDtoForDisplays = GetAllProductDtoForDisplay().OrderBy(product => product.UnitPrice).ToList();
            }
            if (order == "DESC")
            {
                listproductDtoForDisplays = GetAllProductDtoForDisplay().OrderByDescending(product => product.UnitPrice).ToList();
            }
            return listproductDtoForDisplays;
        }
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplayByCategoryId(int categoryId)
        {
            var listproductDtoForDisplays = new List<ProductDtoForDisplay>();
            foreach (var product in GetAllProducts())
            {
                if (product.CategoryId == categoryId)
                {
                    listproductDtoForDisplays.Add(GetProductDtoForDisplayById(product.ProductId));
                }
            }
            return listproductDtoForDisplays;
        } //Codigo repetido para no hacer consultas anidadas a la DB
        public List<ProductDtoForDisplay> GetAllProductDtoForDisplayBySupplierId(int supplierId)
        {
            var listproductDtoForDisplays = new List<ProductDtoForDisplay>();
            foreach (var product in GetAllProducts())
            {
                if (product.SupplierId == supplierId)
                {
                    listproductDtoForDisplays.Add(GetProductDtoForDisplayById(product.ProductId));
                }
            }
            return listproductDtoForDisplays;
        } //Codigo repetido para no hacer consultas anidadas a la DB
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
