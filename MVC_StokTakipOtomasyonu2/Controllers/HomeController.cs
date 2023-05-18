using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu2.Models.Entity;

namespace MVC_StokTakipOtomasyonu2.Controllers
{
    public class HomeController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {


            return View(db.Kategoriler.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle2(Kategoriler p)
        {
            db.Kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("About");
        }
        public ActionResult GuncelleBilgiGetir(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Guncelle(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("About");
        }

        
        public ActionResult Products()
        {

            return View(db.Birimler.ToList());
        }
        [HttpGet]
        public ActionResult EkleBirim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EkleBirim2(Birimler p)
        {
            db.Birimler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        public ActionResult Store()
        {

            var model = db.Markalar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult MarkaEkle()
        {
            var model = new Markalar();
            List<SelectListItem> liste = new List<SelectListItem>(from x in db.Kategoriler
                                                                  select new SelectListItem

                                                                  {
                                                                      Value = x.ID.ToString(),
                                                                      Text = x.Kategori

                                                                  }
            ).ToList();
            // ViewBag.KategoriID = new SelectList(db.Kategoriler,"ID","Kategori",model.KategoriID);
            ViewBag.l = liste;
            return View();
        }
        [HttpPost]
        public ActionResult MarkaEkle(Markalar p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Store");
        }
    }
}