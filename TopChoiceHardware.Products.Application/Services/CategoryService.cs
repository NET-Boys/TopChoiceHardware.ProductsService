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
    public interface ICategoriaService
    {
        Category CreateCategoria(CategoryDto categoria);
        List<Category> GetCategorias();
        Category GetCategoriaById(int id);
    }
    public class CategoryService : ICategoriaService
    {
        private IGenericRepository _repository;

        public CategoryService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Category CreateCategoria(CategoryDto categoria)
        {
            var entity = new Category
            {
                CategoryName = categoria.CategoryName,
                Description = categoria.Description
            };

            _repository.Add(entity);
            return entity;
        }

        public Category GetCategoriaById(int id)
        {
            return _repository.GetById<Category>(id);
        }

        public List<Category> GetCategorias()
        {
            return _repository.GetAll<Category>();
        }
    }
}
