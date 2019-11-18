using PersonelTakip.Models.Veritabani;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PersonelTakip.Controllers
{
    
    public class PersonelController : Controller
  
    {
        MVCPersonelEntities db = new MVCPersonelEntities();
        // GET: Personel

        public ActionResult Index(string ara,int sayfa=1)
        {
            return View(db.TBLPersonel.Where(x=>x.AdiSoyadi.Contains(ara)||ara==null).ToList().ToPagedList(sayfa,3));
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            ViewBag.DepartmanID = new SelectList(db.TBLDepartman, "ID", "Departman");
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TBLPersonel P)
        {
      
            db.TBLPersonel.Add(P);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GuncelleBilgiGetir(TBLPersonel P)
        {
            P = db.TBLPersonel.Find(P.ID);
            ViewBag.DepartmanID = new SelectList(db.TBLDepartman, "ID", "Departman", P.DepartmanID);
            return View(P);
        }

        public ActionResult Guncelle(TBLPersonel P)
        {

            db.Entry(P).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SilBilgiGetir(TBLPersonel P)
        {
            P = db.TBLPersonel.Find(P.ID);

            return View(P);
        }

        public ActionResult Sil(TBLPersonel P)
        {
            P = db.TBLPersonel.Find(P.ID);
            db.Entry(P).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}