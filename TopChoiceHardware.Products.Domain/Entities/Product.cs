using System.Collections.Generic;

namespace TopChoiceHardware.Products.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public bool OnSale { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Image> Carousel { get; set; }
    }
}