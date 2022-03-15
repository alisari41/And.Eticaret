using And.Eticaret.Core.Model;//andDB eklemek için
using And.Eticaret.Core.Model.Entity;//user çağırma
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;//sayfalama yapmak için
using PagedList.Mvc;//sayfalama yapmak için

namespace And.Eticaret.UI.WEB.Controllers
{
    public class HomeController : AndControllerBase
    {
        AndDB db = new AndDB();


        // GET: Home
        public ActionResult Index(int sayfa=1)//1. sayfadan başlasın
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderBy(x => x.CreateDate).ToList().ToPagedList(sayfa, 12);//bir sayfada 12 tane ürün olsun
            return View(data);
        }
        public PartialViewResult GetMenu()
        {
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();
            return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult Login(string Email,string Password)//buradaki isimleri textboxlara verdiğim idlere göre yazıyorum
        {
            var users = db.Users.Where(x => x.Email == Email
              && x.Password == Password
              && x.IsActice == true
              && x.IsAdmin == false).ToList();
            if (users.Count == 1)
            {
                //girişi tamam
                Session["LoginUserID"] = users.FirstOrDefault().ID;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");//  / anasayfa demek
            }
            else
            {//Hata alırsan şifre veya kullanıcı hatası var ise alert göstermek için yaptım
                ViewBag.Error = "Kullanıcı adınız veya şifreniz yanlış olduğu için giriş yapamazsınız!";
                return View();  //olduğun sayfayı göster 
            }
            
            
        }

        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActice = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View();//herhangi bir hata alaınırsa adamın üye kayıt sayfasına gönder
            }
            
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}