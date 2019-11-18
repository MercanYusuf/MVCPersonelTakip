using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelTakip.Models.Veritabani;
using PagedList;

namespace PersonelTakip.Controllers
{
    public class DepartmanController : Controller
    {
        MVCPersonelEntities db = new MVCPersonelEntities();
        // GET: Departman
        public ActionResult Index(string ara,int sayfa=1)
        {
            var liste = db.TBLDepartman.Where(x=>x.Departman.Contains(ara)||ara==null).ToList().ToPagedList(sayfa,3);
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBLDepartman P)
        {
            db.TBLDepartman.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(TBLDepartman P)
        {
            var sil = db.TBLDepartman.Find(P.ID);
            
            
            return View("SilBilgiGetir", sil);
        }
        public ActionResult Sil(TBLDepartman P)
        {
            var sil = db.TBLDepartman.Find(P.ID);
            db.TBLDepartman.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GuncelleBilgiGetir(TBLDepartman P)
        {
            var guncelle = db.TBLDepartman.Find(P.ID);

            return View("GuncelleBilgiGetir", guncelle);
        }


        public ActionResult Guncelle(TBLDepartman P)
        {
            var guncelle = db.TBLDepartman.Find(P.ID);
            guncelle.Departman = P.Departman;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}