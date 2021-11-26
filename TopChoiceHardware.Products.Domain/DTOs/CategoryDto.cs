using System.Collections.Generic;

namespace TopChoiceHardware.Products.Domain.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public  List<ProductDtoForDisplay> Products { get; set; }
    }
}
