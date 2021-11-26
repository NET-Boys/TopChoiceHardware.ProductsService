using System.Collections.Generic;
using System.Linq;
using TopChoiceHardware.Products.Domain.Commands;
using TopChoiceHardware.Products.Domain.Entities;
using TopChoiceHardware.Products.Domain.DTOs;
using AutoMapper;

namespace TopChoiceHardware.Products.AccessData.Commands
{
    public class SupplierRepository: ISupplierRepository
    {
        private readonly ProductsContext _context;
        private readonly IMapper _mapper;
        public SupplierRepository(ProductsContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Add(Supplier supplier)
        {
            _context.Supplier.Add(supplier);
            _context.SaveChanges();
        }   
        public Supplier GetSupplierById(int id)
        {
            return _context.Supplier.SingleOrDefault(Supplier => Supplier.SupplierId == id);
        }
        public SupplierDtoForDisplay GetSupplierDtoForDisplayById(int supplierId)
        {
            var supplier = GetSupplierById(supplierId);
            if (supplier != null)
            {
                var productMapped = _mapper.Map<SupplierDtoForDisplay>(supplier);
                return productMapped;
            }
            return null;
        }
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Supplier.ToList();
        }
        
        public List<SupplierDtoForDisplay> GetAllSupplierDtoForDisplay()
        {
            var listsupplierDtoForDisplays = new List<SupplierDtoForDisplay>();
            foreach (var supplier in GetAllSuppliers())
            {
                listsupplierDtoForDisplays.Add(GetSupplierDtoForDisplayById(supplier.SupplierId));
            }
            return listsupplierDtoForDisplays;
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
     
        public void DeleteById(int id)
        {
            var supplier = GetSupplierById(id);
            _context.Supplier.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
