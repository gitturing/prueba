using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tienda.Models;

namespace tienda.Controllers
{
    public class provedoresController : Controller
    {
        private tiendaEntities db = new tiendaEntities();

        // GET: provedores
        public ActionResult Index()
        {
            return View(db.provedores.ToList());
        }

        // GET: provedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provedores provedores = db.provedores.Find(id);
            if (provedores == null)
            {
                return HttpNotFound();
            }
            return View(provedores);
        }

        // GET: provedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: provedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_provedor,nombre_provedor,direccion,telefono,correo")] provedores provedores)
        {
            if (ModelState.IsValid)
            {
                db.provedores.Add(provedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provedores);
        }

        // GET: provedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provedores provedores = db.provedores.Find(id);
            if (provedores == null)
            {
                return HttpNotFound();
            }
            return View(provedores);
        }

        // POST: provedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_provedor,nombre_provedor,direccion,telefono,correo")] provedores provedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provedores);
        }

        // GET: provedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provedores provedores = db.provedores.Find(id);
            if (provedores == null)
            {
                return HttpNotFound();
            }
            return View(provedores);
        }

        // POST: provedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            provedores provedores = db.provedores.Find(id);
            db.provedores.Remove(provedores);
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
