using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStokProject.Models.Entity;
namespace MvcStokProject.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Db_StokEntities db = new Db_StokEntities();
        public ActionResult Index()
        {
            var deger = db.TBL_KATEGORI.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORI p)
        {
            db.TBL_KATEGORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var deger = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGetir(int id)
        {
            var deger = db.TBL_KATEGORI.Find(id);
            return View("KategoriGuncelle", deger);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(TBL_KATEGORI p)
        {
            var deger = db.TBL_KATEGORI.Find(p.ID);
            deger.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}