using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    /// <summary>
    /// Products DTO
    /// </summary>
    public class ProductsDTO
    {
        public List<ProductDTO> Items { get; set; }
    }
}