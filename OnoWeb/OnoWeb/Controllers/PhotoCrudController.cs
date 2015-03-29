using OnoWeb.DAL;
using OnoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnoWeb.Controllers
{
    public class PhotoCrudController : Controller
    {
        private OnoContext db = new OnoContext();

        // GET: PhotosCrud
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        // GET: PhotosCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
               Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: PhotoCrud/Create
        public ActionResult Create()
        {
            var oners = new List<string>();
            var onerQuery = from o in db.Oners
                              orderby o.FirstName
                              select o.FirstName;

            oners.AddRange(onerQuery);
            ViewBag.onerList = new SelectList(oners);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] PhotoViewModel photoVm, string onerFirstName)
        {
            if (ModelState.IsValid)
            {
                Photo photo = new Photo();
                photo.Name = photoVm.Name;

                var anOner = (from o in db.Oners
                              where o.FirstName == onerFirstName
                              select o).FirstOrDefault<Oner>();
                photo.OnerID = anOner.OnerID;
                // TODO: Get author object from db by name
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photoVm);
        }


        // GET: PhotosCrud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: PhotosCrud/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotoID, Name, PhotoFile, AlbumID, OnerID")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: PhotosCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
               Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: BooksCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
