using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.Eticaret.Core.Model.Entity
{
    public class Basket : EntityBase
    {//Sepet
        public int UserID { get; set; }//kime ait
        public int ProductID { get; set; }//hangi ürün
        public Product Product{ get; set; }//ürünün diğer bilgileride bize lazım olduğu için productla ilişki kuruyoruz
        public int Quantity { get; set; }//adet
    }
}
