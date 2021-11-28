using System.Collections.Generic;

namespace TopChoiceHardware.Products.Domain.DTOs
{
    public class ProductDtoForDisplay
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public bool OnSale { get; set; }
        public virtual List<string> Carousel { get; set; }
    }
}
