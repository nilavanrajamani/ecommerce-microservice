using AspnetRun.Services.Orders.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Services.Orders.Core.Entities
{
    public class Product : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }       
    }
}
