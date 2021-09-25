using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.Products.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
