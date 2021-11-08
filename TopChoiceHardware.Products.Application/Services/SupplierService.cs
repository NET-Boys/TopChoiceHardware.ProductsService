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
    public interface ISupplierService
    {
        Supplier CreateSupplier(SupplierDto proveedor);
        List<Supplier> GetSuppliers();
        Supplier GetSupplierById(int id);
    }
    public class SupplierService : ISupplierService
    {
        private IGenericRepository _repository;

        public SupplierService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Supplier CreateSupplier(SupplierDto proveedor)
        {
            var entity = new Supplier
            {
                CompanyName = proveedor.CompanyName,
                Email = proveedor.Email,
                Phone = proveedor.Phone,
                AddressId = proveedor.AddressId
            };

            _repository.Add(entity);
            return entity;
        }

        public Supplier GetSupplierById(int id)
        {
            return _repository.GetById<Supplier>(id);
        }

        public List<Supplier> GetSuppliers()
        {
            return _repository.GetAll<Supplier>();
        }
    }
}
