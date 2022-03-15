using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;//DbContext ten miras alabilmek için
using And.Eticaret.Core.Model.Entity;//diğer User tablosuna erişmek için
using System.Data.Entity.ModelConfiguration.Conventions;

namespace And.Eticaret.Core.Model
{
    public class AndDB : DbContext //public olmalı her taraftan erişebilinmeli
    {//database burdan erişecem
     //Tablolar

        public AndDB() : base(@"Data Source=.\sqlexpress;Initial Catalog=AndEticaretDB;Integrated Security=True")
        {
        }
        //buraya ekliyorummki çağırdığımda  database gidip oluştursun
        public DbSet<User> Users { get; set; }//Dbset ekledim User tablosu için
        public DbSet<UserAddress> UserAddresses { get; set; }//Dbset ekledim UserAddress tablosu için
        public DbSet<Category> Categories { get; set; }//Dbset ekledim Category tablosu için
        public DbSet<Product> Products { get; set; }//Dbset ekledim Product tablosu için
        public DbSet<Status> Statuses { get; set; }//Dbset ekledim Status(DURUM) tablosu için
        public DbSet<Basket> Baskets { get; set; }//sepet
        public DbSet<Order> Orders { get; set; }//sipariş Ana tablo
        public DbSet<OrderProduct> OrderProducts { get; set; }//sipariş ürün bilgileri
        public DbSet<OrderPayment> OrderPayments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
