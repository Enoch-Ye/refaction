using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Models.Products
{
    /// <summary>
    /// Product Option Entity
    /// </summary>
    public class ProductOption : BaseModel
    {
        public Guid ProductId{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
