using System.Collections.Generic;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Domain.Commands
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        List<Category> GetAllCategorys();
        void Update(Category category);
        void Delete(Category category);
        void DeleteById(int id);
        Category GetCategoryById(int id);
        List<Product> GetListProductsOfCategoryByCategoryId(int categoryId);
        CategoryDto GetCategoryDtoForDisplayById(int categoryId);
        List<CategoryDto> GetAllCategoryDtosForDisplay();
    }
}
