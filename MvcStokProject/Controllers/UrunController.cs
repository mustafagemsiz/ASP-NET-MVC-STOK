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
            var deger = db.TBL_URUN.Where(x=>x.DURUM==true).ToList();
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
            p.DURUM = true;
            db.TBL_URUN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kategoriList = (from x in db.TBL_KATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            var deger = db.TBL_URUN.Find(id);
            ViewBag.kategori = kategoriList;
            return View("UrunGetir",deger);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(TBL_URUN p)
        {
            var urun = db.TBL_URUN.Find(p.ID);
            urun.MARKA = p.MARKA;
            urun.SATİSFİYAT = p.SATİSFİYAT;
            urun.STOK = p.STOK;
            urun.ALİSFİYAT = p.ALİSFİYAT;
            urun.AD = p.AD;
            urun.DURUM = true;
            var kategoriDeger = db.TBL_KATEGORI.Where(x => x.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            urun.KATEGORI = kategoriDeger.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult UrunSil(TBL_URUN p)
        {
            var deger = db.TBL_URUN.Find(p.ID);
            deger.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}