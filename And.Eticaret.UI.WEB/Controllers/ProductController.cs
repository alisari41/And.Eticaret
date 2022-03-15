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
    public class ProductController : AndControllerBase
    {
        // GET: Product
        [Route("Urun/{title}/{id}")]
        public ActionResult Deteil(string title, int id)
        {
            var db = new AndDB();
            ViewBag.IsLogin = this.IsLogin;
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(prod);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            Session.Clear();
            return Redirect("/");
        }
    }
}