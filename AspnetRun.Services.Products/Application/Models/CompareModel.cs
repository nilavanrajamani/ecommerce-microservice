using AspnetRun.Services.Products.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Application.Models
{
    public class CompareModel : BaseModel
    {
        public string UserName { get; set; }
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
    }
}
