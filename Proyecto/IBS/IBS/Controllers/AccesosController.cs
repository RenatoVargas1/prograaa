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
    public class AccesosController : Controller
    {
        private IBSEntities db = new IBSEntities();

        // GET: Accesos
        public ActionResult Index()
        {
            var acceso = db.Acceso.Include(a => a.Usuario);
            return View(acceso.ToList());
        }

        // GET: Accesos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acceso acceso = db.Acceso.Find(id);
            if (acceso == null)
            {
                return HttpNotFound();
            }
            return View(acceso);
        }

        // GET: Accesos/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioDni = new SelectList(db.Usuario, "Dni", "Apellidos");
            return View();
        }

        // POST: Accesos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,contraseña,UsuarioDni")] Acceso acceso)
        {
            if (ModelState.IsValid)
            {
                db.Acceso.Add(acceso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioDni = new SelectList(db.Usuario, "Dni", "Apellidos", acceso.UsuarioDni);
            return View(acceso);
        }

        // GET: Accesos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acceso acceso = db.Acceso.Find(id);
            if (acceso == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioDni = new SelectList(db.Usuario, "Dni", "Apellidos", acceso.UsuarioDni);
            return View(acceso);
        }

        // POST: Accesos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,contraseña,UsuarioDni")] Acceso acceso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acceso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioDni = new SelectList(db.Usuario, "Dni", "Apellidos", acceso.UsuarioDni);
            return View(acceso);
        }

        // GET: Accesos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acceso acceso = db.Acceso.Find(id);
            if (acceso == null)
            {
                return HttpNotFound();
            }
            return View(acceso);
        }

        // POST: Accesos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Acceso acceso = db.Acceso.Find(id);
            db.Acceso.Remove(acceso);
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
