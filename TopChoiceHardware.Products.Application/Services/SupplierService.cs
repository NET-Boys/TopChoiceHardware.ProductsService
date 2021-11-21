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
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int id);
    }
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public Supplier CreateSupplier(SupplierDto supplier)
        {
            var entity = new Supplier
            {
                CompanyName = supplier.CompanyName,
                Email = supplier.Email,
                Phone = supplier.Phone,
                AddressId = supplier.AddressId
            };

            _repository.Add(entity);
            return entity;
        }

        public Supplier GetSupplierById(int id)
        {
            return _repository.GetSupplierById(id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _repository.GetAllSuppliers();
        }
    }
}
