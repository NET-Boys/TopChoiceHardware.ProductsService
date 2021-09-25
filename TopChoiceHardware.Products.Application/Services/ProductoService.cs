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
    public interface IProductoService
    {
        Producto CreateProducto(ProductoDto producto);
        List<Producto> GetProductos();
        Producto GetProductoById(int id);
    }
    public class ProductoService : IProductoService
    {
        private IGenericRepository _repository;

        public ProductoService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Producto CreateProducto(ProductoDto producto)
        {
            var entity = new Producto
            {
                ProductName = producto.ProductName,
                CategoryId = producto.CategoryId,
                SupplierId = producto.SupplierId,
                UnitPrice = producto.UnitPrice,
                UnitsInStock = producto.UnitsInStock,
                Brand = producto.Brand,
                Description = producto.Description
            };
            
            _repository.Add(entity);
            return entity;
        }

        public Producto GetProductoById(int id)
        {
            return _repository.GetById<Producto>(id);
        }

        public List<Producto> GetProductos()
        {
            return _repository.GetAll<Producto>();
        }
    }
}
