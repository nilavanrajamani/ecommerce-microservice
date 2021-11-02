using AspnetRun.Services.Basket.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Services.Basket.Core.Entities
{
    public class Product : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
