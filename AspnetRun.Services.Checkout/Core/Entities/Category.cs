using AspnetRun.Services.Basket.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Services.Basket.Core.Entities
{
    public class Category : Entity
    {
        [Required, StringLength(80)]
        public string Name { get; set; }
    }
}
