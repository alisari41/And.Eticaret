using And.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;//sayfalama yapmak için
using PagedList.Mvc;//sayfalama yapmak için

namespace And.Eticaret.UI.WEB.Controllers
{
    public class CategoryController : AndControllerBase
    {
        // GET: Category
        [Route("Kategori/{isim}/{id}")]//altaki parametre ile aynı olacak
        public ActionResult Index(string isim,int id,int sayfa=1)
        {
            var db = new AndDB();
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.Where(x => x.IsActive == true
                  && x.CategoryID == id).ToList().ToPagedList(sayfa, 12);//listeyi değişkene atadım onuda sayfama gönderdim. Bir sayfada en falzaa 9 ürün gösteriyorum
            ViewBag.category = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public JsonResult AddProduct(int productID, int quantity)
        {
            var db = new AndDB();
            db.Baskets.Add(new Core.Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserID = LoginUserID,
                ProductID = productID,
                Quantity = quantity,
                UserID = LoginUserID
            });
            var rt = db.SaveChanges();

            return Json(rt, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            Session.Clear();
            return Redirect("/");
        }
    }
}