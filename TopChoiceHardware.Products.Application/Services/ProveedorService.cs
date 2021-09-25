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
    public interface IProveedorService
    {
        Proveedor CreateProveedor(ProveedorDto proveedor);
        List<Proveedor> GetProveedores();
        Proveedor GetProveedorById(int id);
    }
    public class ProveedorService : IProveedorService
    {
        private IGenericRepository _repository;

        public ProveedorService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Proveedor CreateProveedor(ProveedorDto proveedor)
        {
            var entity = new Proveedor
            {
                CompanyName = proveedor.CompanyName,
                Email = proveedor.Email,
                Phone = proveedor.Phone,
                AddressId = proveedor.AddressId
            };

            _repository.Add(entity);
            return entity;
        }

        public Proveedor GetProveedorById(int id)
        {
            return _repository.GetById<Proveedor>(id);
        }

        public List<Proveedor> GetProveedores()
        {
            return _repository.GetAll<Proveedor>();
        }
    }
}
