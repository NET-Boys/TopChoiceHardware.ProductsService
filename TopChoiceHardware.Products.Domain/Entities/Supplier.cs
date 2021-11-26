using System.Collections.Generic;

namespace TopChoiceHardware.Products.Domain.Entities
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
