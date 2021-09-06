using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStokProject.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Pesronel
        Db_StokEntities db = new Db_StokEntities();
        public ActionResult Index()
        {
            var deger = db.TBL_PERSONEL.Where(x=>x.DURUM==true).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONEL p)
        {
            p.DURUM = true;
            db.TBL_PERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(TBL_PERSONEL p)
        {
            var deger = db.TBL_PERSONEL.Find(p.ID);
            deger.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");            
        }

        public ActionResult PersonelGetir(int id)
        {
            var deger = db.TBL_PERSONEL.Find(id);
            return View("PersonelGetir", deger);
        }

        public ActionResult PersonelGuncelle(TBL_PERSONEL p)
        {
            var deger = db.TBL_PERSONEL.Find(p.ID);
            deger.AD = p.AD;
            deger.SOYAD = p.SOYAD;
            deger.ADRES = p.ADRES;
            deger.TELEFON = p.TELEFON;
            deger.DEPARTMAN = p.DEPARTMAN;
            deger.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}