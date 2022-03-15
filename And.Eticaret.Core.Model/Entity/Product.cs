using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.Eticaret.Core.Model.Entity
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }//categroyle ilişki kurdum

        public string Brand { get; set; }//marka
        public string ImageUrl { get; set; }//resim saklıcam
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }//vergi
        public decimal Discount { get; set; }//indirim
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
