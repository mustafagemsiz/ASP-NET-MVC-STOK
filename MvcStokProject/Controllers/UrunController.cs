using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProject.Models.Entity;
namespace MvcStokProject.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Db_StokEntities db = new Db_StokEntities();
        public ActionResult Index()
        {
            var deger = db.TBL_URUN.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger = (from x in db.TBL_KATEGORI.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.kategori = deger;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TBL_URUN p)
        {
            var kategori = db.TBL_KATEGORI.Where(x => x.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            p.TBL_KATEGORI = kategori;
            db.TBL_URUN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}