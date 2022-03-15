using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.Eticaret.Core.Model.Entity
{
    public class OrderProduct : EntityBase
    {//siparişin ürünleri
        public int OrderID { get; set; }//hangi siparrşi ait  ürün listesi
        public int ProductID { get; set; }//hangi ürün
        public Product Product { get; set; }
        public int Quantity { get; set; }//kaç adet ürün alındı
    }
}
