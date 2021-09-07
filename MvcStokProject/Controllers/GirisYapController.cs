using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcStokProject.Controllers
{
    [AllowAnonymous]
    public class GirisYapController : Controller
    {
        
        Db_StokEntities db = new Db_StokEntities();
        // GET: GirisYap
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(TBL_ADMIN p)
        {
            var bilgi = db.TBL_ADMIN.FirstOrDefault(x => x.KULLANICI == p.KULLANICI && x.SIFRE == p.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICI, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }

           
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Giris", "GirisYap");
        }
    }
}