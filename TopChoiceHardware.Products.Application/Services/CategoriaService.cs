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
        Categoria CreateCategoria(CategoriaDto categoria);
        List<Categoria> GetCategorias();
        Categoria GetCategoriaById(int id);
    }
    public class CategoriaService : ICategoriaService
    {
        private IGenericRepository _repository;

        public CategoriaService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Categoria CreateCategoria(CategoriaDto categoria)
        {
            var entity = new Categoria
            {
                CategoryName = categoria.CategoryName,
                Description = categoria.Description
            };

            _repository.Add(entity);
            return entity;
        }

        public Categoria GetCategoriaById(int id)
        {
            return _repository.GetById<Categoria>(id);
        }

        public List<Categoria> GetCategorias()
        {
            return _repository.GetAll<Categoria>();
        }
    }
}
