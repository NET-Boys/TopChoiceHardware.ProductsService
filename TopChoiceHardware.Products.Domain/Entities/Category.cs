using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.Products.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Productos = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Productos { get; set; }
    }
}
