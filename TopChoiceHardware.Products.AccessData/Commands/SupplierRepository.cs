using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.AccessData.Commands
{
    public class SupplierRepository: ISupplierRepository
    {
        private readonly ProductsContext _context;
        public SupplierRepository(ProductsContext context)
        {
            _context = context;
        }

        /*
         * List<Supplier> GetAllSuppliers();
        void Update(Supplier supplier);
        void Delete(Supplier supplier);
        void DeleteById(int id);
        Supplier GetSupplierById(int id);*/


        public void Add(Supplier supplier)
        {
            _context.Supplier.Add(supplier);
            _context.SaveChanges();
        }
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Supplier.ToList();
        }
        public void Update(Supplier supplier)
        {
            _context.Supplier.Update(supplier);
            _context.SaveChanges();
        }
        public void Delete(Supplier supplier)
        {
            _context.Supplier.Remove(supplier);
            _context.SaveChanges();
        }
        public Supplier GetSupplierById(int id)
        {
            return _context.Supplier.SingleOrDefault(Supplier => Supplier.SupplierId == id);
        }
        public void DeleteById(int id)
        {
            var supplier = GetSupplierById(id);
            _context.Supplier.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
