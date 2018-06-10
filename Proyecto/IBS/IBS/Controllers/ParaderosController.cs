using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IBS;

namespace IBS.Controllers
{
    public class ParaderosController : Controller
    {
        private IBSEntities db = new IBSEntities();

        // GET: Paraderos
        public ActionResult Index()
        {
            return View(db.Paradero.ToList());
        }

        // GET: Paraderos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paradero paradero = db.Paradero.Find(id);
            if (paradero == null)
            {
                return HttpNotFound();
            }
            return View(paradero);
        }

        // GET: Paraderos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paraderos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Paradero paradero)
        {
            if (ModelState.IsValid)
            {
                db.Paradero.Add(paradero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paradero);
        }

        // GET: Paraderos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paradero paradero = db.Paradero.Find(id);
            if (paradero == null)
            {
                return HttpNotFound();
            }
            return View(paradero);
        }

        // POST: Paraderos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Paradero paradero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paradero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paradero);
        }

        // GET: Paraderos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paradero paradero = db.Paradero.Find(id);
            if (paradero == null)
            {
                return HttpNotFound();
            }
            return View(paradero);
        }

        // POST: Paraderos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paradero paradero = db.Paradero.Find(id);
            db.Paradero.Remove(paradero);
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
