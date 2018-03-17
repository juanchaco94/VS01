using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VS01.Models;

namespace VS01.Controllers
        // GET: people
{
    public class peopleController : Controller
    {
        private VS01Context db = new VS01Context();

        public ActionResult Index()
        {
            var people = db.people.Include(p => p.genders).Include(p => p.rol);
            return View(people.ToList());
        }

        // GET: people/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = db.people.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: people/Create
        public ActionResult Create()
        {
            ViewBag.IdGender = new SelectList(db.genders, "IdGender", "description");
            ViewBag.IdRol = new SelectList(db.rols, "IdRol", "description");
            ViewBag.IdDocumentType = new SelectList(db.documentTypes, "IdDocumentType", "description");
            return View();
        }

        // POST: people/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPerson,firstName,lastName,IdDocumetType,identityNumber,phone,email,birthDate,IdRol,address,IdGender,status")] person person)
        {
            if (ModelState.IsValid)
            {
                db.people.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGender = new SelectList(db.genders, "IdGender", "description", person.IdGender);
            ViewBag.IdRol = new SelectList(db.rols, "IdRol", "description", person.IdRol);
            return View(person);
        }

        // GET: people/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = db.people.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGender = new SelectList(db.genders, "IdGender", "description", person.IdGender);
            ViewBag.IdRol = new SelectList(db.rols, "IdRol", "description", person.IdRol);
            return View(person);
        }

        // POST: people/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPerson,firstName,lastName,IdDocumetType,identityNumber,phone,email,birthDate,IdRol,address,IdGender,status")] person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGender = new SelectList(db.genders, "IdGender", "description", person.IdGender);
            ViewBag.IdRol = new SelectList(db.rols, "IdRol", "description", person.IdRol);
            return View(person);
        }

        // GET: people/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            person person = db.people.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: people/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            person person = db.people.Find(id);
            db.people.Remove(person);
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
