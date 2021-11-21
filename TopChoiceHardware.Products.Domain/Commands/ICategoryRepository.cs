using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
