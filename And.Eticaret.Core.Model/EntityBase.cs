using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.Eticaret.Core.Model
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }
        public DateTime CreateDate{ get; set; }
        public int CreateUserID { get; set; }
        public DateTime? UpdateDate{ get; set; }//kayıt update edilene kadar boşta olabilir
        public int? UpdateUserID { get; set; }//bunlar zorunlu değil boş bırakılabilir o yüzden ? var


    }
}
