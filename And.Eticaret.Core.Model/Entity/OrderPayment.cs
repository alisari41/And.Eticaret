using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.Eticaret.Core.Model.Entity
{
    public class OrderPayment : EntityBase
    {
        public int OrderOD { get; set; }
        public _OrderType OrderType { get; set; }
        public decimal Price { get; set; }//ne kadar ödenmiş bunun için order sınııfnda liste tutturdum çünkü az para veya birden fazla eft olabilir.
        public string Bank { get; set; }
    }
    public enum _OrderType
    {
        Havale=0,
        KrediKarti=1
    }
}
