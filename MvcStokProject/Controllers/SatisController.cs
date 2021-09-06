using MvcStokProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStokProject.Controllers
{
    public class SatisController : Controller
    {
        Db_StokEntities db = new Db_StokEntities();
        public ActionResult Index()
        {
            var deger = db.TBL_SATIS.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            //Ürün Listesi
            List<SelectListItem> urun = (from x in db.TBL_URUN.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.urunList = urun;

            //Personel Listesi
            List<SelectListItem> personel = (from x in db.TBL_PERSONEL.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD+" "+x.SOYAD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.personelList = personel;

            //Müşteri Listesi
            List<SelectListItem> musteri = (from x in db.TBL_MUSTERI.Where(x=>x.DURUM==true).ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD+" "+x.SOYAD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.musteriList = musteri;


            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(TBL_SATIS p)
        {
            var urun = db.TBL_URUN.Where(x => x.ID == p.TBL_URUN.ID).FirstOrDefault();
            var personel = db.TBL_PERSONEL.Where(x => x.ID == p.TBL_PERSONEL.ID).FirstOrDefault();
            var musteri = db.TBL_MUSTERI.Where(x => x.ID == p.TBL_MUSTERI.ID).FirstOrDefault();
            p.TBL_URUN = urun;
            p.TBL_PERSONEL = personel;
            p.TBL_MUSTERI = musteri;
            p.TARIH = DateTime.Parse(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            db.TBL_SATIS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}