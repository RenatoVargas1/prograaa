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
    public class LineasController : Controller
    {
        private IBSEntities db = new IBSEntities();

        // GET: Lineas
        public ActionResult Index()
        {
            var lineas = db.Lineas.Include(l => l.Empresa1).Include(l => l.Estado1);
            return View(lineas.ToList());
        }

        // GET: Lineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lineas lineas = db.Lineas.Find(id);
            if (lineas == null)
            {
                return HttpNotFound();
            }
            return View(lineas);
        }

        // GET: Lineas/Create
        public ActionResult Create()
        {
            ViewBag.Empresa = new SelectList(db.Empresa, "RUC", "RazonSocial");
            ViewBag.Estado = new SelectList(db.Estado, "Codigo", "Descripcion");
            return View();
        }

        // POST: Lineas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Empresa,Estado")] Lineas lineas)
        {
            if (ModelState.IsValid)
            {
                db.Lineas.Add(lineas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empresa = new SelectList(db.Empresa, "RUC", "RazonSocial", lineas.Empresa);
            ViewBag.Estado = new SelectList(db.Estado, "Codigo", "Descripcion", lineas.Estado);
            return View(lineas);
        }

        // GET: Lineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lineas lineas = db.Lineas.Find(id);
            if (lineas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empresa = new SelectList(db.Empresa, "RUC", "RazonSocial", lineas.Empresa);
            ViewBag.Estado = new SelectList(db.Estado, "Codigo", "Descripcion", lineas.Estado);
            return View(lineas);
        }

        // POST: Lineas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Empresa,Estado")] Lineas lineas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empresa = new SelectList(db.Empresa, "RUC", "RazonSocial", lineas.Empresa);
            ViewBag.Estado = new SelectList(db.Estado, "Codigo", "Descripcion", lineas.Estado);
            return View(lineas);
        }

        // GET: Lineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lineas lineas = db.Lineas.Find(id);
            if (lineas == null)
            {
                return HttpNotFound();
            }
            return View(lineas);
        }

        // POST: Lineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lineas lineas = db.Lineas.Find(id);
            db.Lineas.Remove(lineas);
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
