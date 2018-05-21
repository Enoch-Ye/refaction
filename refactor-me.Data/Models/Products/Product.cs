using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Models.Products
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
