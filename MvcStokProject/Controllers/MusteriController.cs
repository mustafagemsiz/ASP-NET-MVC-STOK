using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using PagedList;
//using PagedList.Mvc;
namespace MvcStokProject.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        Db_StokEntities db = new Db_StokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var deger = db.TBL_MUSTERI.Where(x=>x.DURUM==true).ToList();
            //var deger = db.TBL_MUSTERI.Where(x=>x.DURUM==true).ToList().ToPagedList(sayfa,3);
            return View(deger);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(TBL_MUSTERI p)
        {
            p.DURUM = true;
            db.TBL_MUSTERI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(TBL_MUSTERI p)
        {
            var deger = db.TBL_MUSTERI.Find(p.ID);
            deger.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var deger = db.TBL_MUSTERI.Find(id);
            return View("MusteriGetir", deger);
        }

        public ActionResult MusteriGuncelle(TBL_MUSTERI p)
        {
            var deger = db.TBL_MUSTERI.Find(p.ID);
            deger.AD = p.AD;
            deger.SOYAD = p.SOYAD;
            deger.SEHIR = p.SEHIR;
            deger.ADRES = p.ADRES;
            deger.BAKIYE = p.BAKIYE;
            deger.TELEFON = p.TELEFON;
            deger.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}