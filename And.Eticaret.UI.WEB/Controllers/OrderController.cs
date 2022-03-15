using And.Eticaret.Core.Model;
using And.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Controllers
{
    public class OrderController : AndControllerBase
    {
        // GET: Order
        [Route("Siparisver")]//adı
        public ActionResult AddressList()
        {
            var db = new AndDB();
            var data = db.UserAddresses.Where(x => x.UserID == LoginUserID).ToList();//Listeleme işlemi

            return View(data);
        }
        public ActionResult CreateUserAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUserID = LoginUserID;
            entity.IsActive = true;
            entity.UserID = LoginUserID;

            var db = new AndDB();
            db.UserAddresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }
        public ActionResult CreateOrder(int id)
        {//kim olduğu id den geliyor hangi ürünler olduğu sepetten geliyor
            var db = new AndDB();

            //productta lazım olucak ürün biligleri için
            var sepet = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.CreateUserID = LoginUserID;
            order.StatusID = 1;
            order.TotalProductPrice = sepet.Sum(x => x.Product.Price);//ürün ana fiyatları topla getir
            order.TotalTaxPrice = sepet.Sum(x => x.Product.Tax);//ürün vergi fiyatları topla getir
            order.TotalDiscount = sepet.Sum(x => x.Product.Discount);// toplam indirim Zaten indirim düşmüş oluyor show amacıyla kişiye göstericez
            order.TotalPrice = order.TotalProductPrice + order.TotalTaxPrice;//ana para artı vergiler toplam fiyat elde ederiz
            order.UserAddressID = id;
            order.UserID = LoginUserID;
            order.OrderProducts = new List<OrderProduct>();
            foreach (var item in sepet)//sepet için dön
            {
                order.OrderProducts.Add(new OrderProduct
                {//ürünleri eklemiş oldum siparişlerin içine
                    CreateDate = DateTime.Now,
                    CreateUserID = LoginUserID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity
                });
                db.Baskets.Remove(item);//ödenen elemanları sil
            }
            db.Orders.Add(order);

            db.SaveChanges();
            
            return RedirectToAction("Detail", new { id = order.ID });
        }
        public ActionResult Detail(int id)
        {
            var db = new AndDB();
            var data = db.Orders.Include("OrderProducts")
                .Include("OrderProducts.Product")
                .Include("OrderPayments")
                .Include("Status")
                .Include("UserAddress")
                .Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
        [Route("Siparislerim")]
        public ActionResult Index()
        {//sadece kişinin siparişlerini göreceği ver burası
            var db = new AndDB();
            var data = db.Orders.Include("Status").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Pay(int id)
        {
            var db = new AndDB();
            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            order.StatusID = 10;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = order.ID });
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            Session.Clear();
            return Redirect("/");
        }
    }
}