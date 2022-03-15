using And.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Controllers
{
    public class BasketController : AndControllerBase
    {
        // GET: Basket
        [HttpPost]
        public JsonResult AddProduct(int productID,int quantity)
        {
            var db = new AndDB();
            db.Baskets.Add(new Core.Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserID=LoginUserID,
                ProductID=productID,
                Quantity=quantity,
                UserID=LoginUserID
            });
            var rt = db.SaveChanges();
            
            return Json(rt,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            Session.Clear();
            return Redirect("/");
        }

        [Route("Sepetim")]
        public ActionResult Index()
        {//sepetime basınca sepeti listeleyecek
            var db = new AndDB();
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        
        public ActionResult Delete(int id)
        {
            var db = new AndDB();
            var deleteitem = db.Baskets.Where(x => x.ID == id).FirstOrDefault();
            db.Baskets.Remove(deleteitem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}