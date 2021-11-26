using AutoMapper;
using System.Collections.Generic;
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
        List<Product> GetListProductsForCategoryId(int categoryId);
        CategoryDto GetCategoryDtoForDisplayById(int categoryId);
        List<CategoryDto> GetAllCategoryDtosForDisplay();
    }
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public List<Product> GetListProductsForCategoryId(int categoryId)
        {
            return _repository.GetListProductsOfCategoryByCategoryId(categoryId);
        }
        public CategoryDto GetCategoryDtoForDisplayById(int categoryId)
        {
            return _repository.GetCategoryDtoForDisplayById(categoryId);
        }
        public List<CategoryDto> GetAllCategoryDtosForDisplay()
        {
            return _repository.GetAllCategoryDtosForDisplay();
        }
    }
}
