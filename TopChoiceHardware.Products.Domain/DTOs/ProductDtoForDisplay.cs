using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.Products.Domain.DTOs
{
    class ProductDtoForDisplay
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
