using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;//controller nesnesinden türetmek için kalıtım için
using System.Web.Routing;

namespace And.Eticaret.UI.WEB.Areas.Admin
{
    public class AdminControllerBase : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            var IsLogin = false;
            if (requestContext.HttpContext.Session["AdminLoginUser"] == null)
            {
                //admin girişi yapılmamış
                requestContext.HttpContext.Response.Redirect("Admin/AdminLogin");
               //admin girişe sayfayı yönlendir.
                //redirect("....")bunu kullanamadık redirectte ezme işlemi yaptık override sayfa yönlendirir.
            }
            else
            {
                //sorun yok admin ieçerde
                //sayfayı çalıştır
                base.Initialize(requestContext);

            }
        }
    }
}