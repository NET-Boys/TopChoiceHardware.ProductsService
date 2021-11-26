using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.AccessData.Commands
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ProductsContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ProductsContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Add(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }
        public List<Category> GetAllCategorys()
        {
            return _context.Category.ToList();
        }
        public void Update(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }
        public void Delete(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
        public Category GetCategoryById(int id)
        {
            return _context.Category.SingleOrDefault(category => category.CategoryId == id);
        }
        
        public CategoryDto GetCategoryDtoForDisplayById(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                var categoryMapped = _mapper.Map<CategoryDto>(category);
                var productsMapped = _mapper.Map<List<ProductDtoForDisplay>>(GetListProductsOfCategoryByCategoryId(categoryId));
                categoryMapped.Products = productsMapped;
                return categoryMapped;
            }
            return null;
        }
        public List<Product> GetListProductsOfCategoryByCategoryId(int categoryId)
        {
            var products = _context.Product.Where(products => products.CategoryId == categoryId);
            var productslist = new List<Product>();
            foreach (var product in products)
            {
                productslist.Add(product);
            }
            return productslist;
        }
        public List<CategoryDto> GetAllCategoryDtosForDisplay()
        {
            var listcategoryDtos = new List<CategoryDto>();
            foreach (var category in GetAllCategorys())
            {
                listcategoryDtos.Add(GetCategoryDtoForDisplayById(category.CategoryId));
            }
            return listcategoryDtos;
        }
        public void DeleteById(int id)
        {
            var category = GetCategoryById(id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
        
    }
}
