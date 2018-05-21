using refactor_me.Models.ProductOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    /// <summary>
    /// Product DTO
    /// </summary>
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public List<ProductOptionDTO> ProductOptions { get; set; }
    }
}