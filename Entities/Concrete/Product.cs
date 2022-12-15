using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    { 

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? Offer { get; set; }
        public List<ProductPicture> ProductPicture { get; set; }
        public string CoverPhoto { get; set; }
    }
}
