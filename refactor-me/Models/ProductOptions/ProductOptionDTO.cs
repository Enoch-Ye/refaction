using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models.ProductOptions
{
    /// <summary>
    /// ProductOptionDTO
    /// </summary>
    public class ProductOptionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}