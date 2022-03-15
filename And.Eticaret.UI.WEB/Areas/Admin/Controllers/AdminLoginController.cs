using And.Eticaret.Core.Model;//veri çekmek için yazdım
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        AndDB db = new AndDB();//veri çekmek için
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {//butonu kullana bilmke için yaptım post yani geleen değerleri gönder gibi
            var data = db.Users.Where(x => x.Email == Email
            && x.Password == Password
            && x.IsActice == true
            && x.IsAdmin == true).ToList();//tablodaki email ile benim giridiğim email eşitmi ve passwoord içinde geçerli
            if (data.Count == 1)
            {
                //doğru giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();//tüm verileri attım içine
                return Redirect("/admin");//kendini admin sayfasına gönder
            }
            else
            {
                //hatalı giriş
                ViewBag.Error = "Yönetici adınız veya şifreniz yanlış olduğu için giriş yapamazsınız!";
                return View();//ise aynı sayfaya dön
            }
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            Session.Clear();
            return Redirect("/");
        }
    }
}