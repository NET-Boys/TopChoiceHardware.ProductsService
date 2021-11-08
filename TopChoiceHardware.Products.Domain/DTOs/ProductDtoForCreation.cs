using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.Products.Domain.DTOs
{
    public class ProductDtoForCreation
    {
        [StringLength(60, MinimumLength = 4)]
        public string ProductName { get; set; }
        [StringLength(55, MinimumLength = 4)]
        public string Brand { get; set; }
        [StringLength(300, MinimumLength = 4)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}