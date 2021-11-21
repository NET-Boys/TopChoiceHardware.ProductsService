using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.AccessData.Commands
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ProductsContext _context;
        public CategoryRepository(ProductsContext context)
        {
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
        public void DeleteById(int id)
        {
            var category = GetCategoryById(id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
        
    }
}
