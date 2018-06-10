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
    public class RutaLineasController : Controller
    {
        private IBSEntities db = new IBSEntities();

        // GET: RutaLineas
        public ActionResult Index()
        {
            var rutaLinea = db.RutaLinea.Include(r => r.Lineas).Include(r => r.Paradero1);
            return View(rutaLinea.ToList());
        }

        // GET: RutaLineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaLinea rutaLinea = db.RutaLinea.Find(id);
            if (rutaLinea == null)
            {
                return HttpNotFound();
            }
            return View(rutaLinea);
        }

        // GET: RutaLineas/Create
        public ActionResult Create()
        {
            ViewBag.Linea = new SelectList(db.Lineas, "Id", "Nombre");
            ViewBag.Paradero = new SelectList(db.Paradero, "Id", "Descripcion");
            return View();
        }

        // POST: RutaLineas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Linea,Paradero,Ruta,Numero")] RutaLinea rutaLinea)
        {
            if (ModelState.IsValid)
            {
                db.RutaLinea.Add(rutaLinea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Linea = new SelectList(db.Lineas, "Id", "Nombre", rutaLinea.Linea);
            ViewBag.Paradero = new SelectList(db.Paradero, "Id", "Descripcion", rutaLinea.Paradero);
            return View(rutaLinea);
        }

        // GET: RutaLineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaLinea rutaLinea = db.RutaLinea.Find(id);
            if (rutaLinea == null)
            {
                return HttpNotFound();
            }
            ViewBag.Linea = new SelectList(db.Lineas, "Id", "Nombre", rutaLinea.Linea);
            ViewBag.Paradero = new SelectList(db.Paradero, "Id", "Descripcion", rutaLinea.Paradero);
            return View(rutaLinea);
        }

        // POST: RutaLineas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Linea,Paradero,Ruta,Numero")] RutaLinea rutaLinea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutaLinea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Linea = new SelectList(db.Lineas, "Id", "Nombre", rutaLinea.Linea);
            ViewBag.Paradero = new SelectList(db.Paradero, "Id", "Descripcion", rutaLinea.Paradero);
            return View(rutaLinea);
        }

        // GET: RutaLineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RutaLinea rutaLinea = db.RutaLinea.Find(id);
            if (rutaLinea == null)
            {
                return HttpNotFound();
            }
            return View(rutaLinea);
        }

        // POST: RutaLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RutaLinea rutaLinea = db.RutaLinea.Find(id);
            db.RutaLinea.Remove(rutaLinea);
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
