using System.Collections.Generic;
using TopChoiceHardware.Products.Domain.DTOs;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.Domain.Commands
{
    public interface ISupplierRepository
    {
        void Add(Supplier supplier);
        List<Supplier> GetAllSuppliers();
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
        void DeleteById(int id);
        Supplier GetSupplierById(int id);
        SupplierDtoForDisplay GetSupplierDtoForDisplayById(int supplierId);
        List<SupplierDtoForDisplay> GetAllSupplierDtoForDisplay();
    }
}
