using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.Products.Domain.DTOs
{
    public class ProductDtoForDisplay
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        //public List<string> Images { get; set; }  //this will be a problem xd
        public string Url { get; set; }
        public bool OnSale { get; set; }

    }
}
