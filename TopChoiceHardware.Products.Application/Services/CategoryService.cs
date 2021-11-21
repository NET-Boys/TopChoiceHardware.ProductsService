using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Application.Services
{
    public interface ICategoryService
    {
        Category CreateCategory(CategoryDto categoria);
        List<Category> GetAllCategorys();
        Category GetCategoryById(int id);
    }
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category CreateCategory(CategoryDto category)
        {
            var entity = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description
            };

            _repository.Add(entity);
            return entity;
        }

        public Category GetCategoryById(int id)
        {
            return _repository.GetCategoryById(id);
        }
        public List<Category> GetAllCategorys()
        {
            return _repository.GetAllCategorys();
        }
    }
}
