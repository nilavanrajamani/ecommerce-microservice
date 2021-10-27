using AspnetRun.Services.Products.Core.Entities.Base;

namespace AspnetRun.Services.Products.Core.Entities
{
    public class Review : Entity
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Comment { get; set; }        
        public double Star { get; set; }
    }
}
