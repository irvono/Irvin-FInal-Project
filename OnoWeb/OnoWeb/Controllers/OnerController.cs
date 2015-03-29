using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using PagedList;
using System.Web;
using System.Web.Mvc;
using OnoWeb.DAL;
using OnoWeb.Models;

namespace OnoWeb.Controllers
{
    public class OnerController : Controller
    {
        private OnoContext db = new OnoContext();

        // GET: Oner
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SkillSortParm = sortOrder == "skill" ? "skill_desc" : "skill";
            var oners = from o in db.Oners
                           select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                oners = oners.Where(o => o.LastName.Contains(searchString)
                                    || o.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    oners = oners.OrderByDescending(o => o.LastName);
                    break;
                case "skill":
                    oners = oners.OrderBy(o => o.Skill);
                    break;
                case "skill_desc":
                    oners = oners.OrderByDescending(o => o.Skill);
                    break;
                default:
                    oners = oners.OrderBy(o => o.LastName);
                    break;
            }
            return View(oners.ToList());
        }

        // GET: Oner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oner oner = db.Oners.Find(id);
            if (oner == null)
            {
                return HttpNotFound();
            }
            return View(oner);
        }

        // GET: Oner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OnerID,LastName,FirstName,Email,Skill,Password,Address,Phone")] Oner oner)
        {
            if (ModelState.IsValid)
            {
                db.Oners.Add(oner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oner);
        }

        // GET: Oner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oner oner = db.Oners.Find(id);
            if (oner == null)
            {
                return HttpNotFound();
            }
            return View(oner);
        }

        // POST: Oner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OnerID,LastName,FirstName,Email,Skill,Password,Address,Phone")] Oner oner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oner);
        }

        // GET: Oner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oner oner = db.Oners.Find(id);
            if (oner == null)
            {
                return HttpNotFound();
            }
            return View(oner);
        }

        // POST: Oner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oner oner = db.Oners.Find(id);
            db.Oners.Remove(oner);
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
