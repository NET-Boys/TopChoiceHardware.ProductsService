using System.Collections.Generic;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Application.Services
{
    public interface ISupplierService
    {
        Supplier CreateSupplier(SupplierDtoForDisplay proveedor);
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int id);
        SupplierDtoForDisplay GetSupplierDtoForDisplayById(int supplierId);
        List<SupplierDtoForDisplay> GetAllSupplierDtoForDisplay();
    }
    public class SupplierService : ISupplierService
    {
        private ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public Supplier CreateSupplier(SupplierDtoForDisplay supplier)
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
        public SupplierDtoForDisplay GetSupplierDtoForDisplayById(int supplierId)
        {
            return _repository.GetSupplierDtoForDisplayById(supplierId);
        }
        public List<SupplierDtoForDisplay> GetAllSupplierDtoForDisplay()
        {
            return _repository.GetAllSupplierDtoForDisplay();
        }
    }
}
