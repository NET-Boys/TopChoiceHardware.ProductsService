using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
