using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace tienda.Controllers
{
    public class productosController : Controller
    {
        private tiendaEntities db = new tiendaEntities();

        // GET: productos
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.provedores);
            return View(productos.ToList());
        }

        // GET: productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: productos/Create
        public ActionResult Create()
        {
            ViewBag.id_provedor = new SelectList(db.provedores, "id_provedor", "nombre_provedor");
            return View();
        }

        // POST: productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_produto,nombre_producto,precio,producto_cantidad,descripcion_producto,id_provedor")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_provedor = new SelectList(db.provedores, "id_provedor", "nombre_provedor", productos.id_provedor);
            return View(productos);
        }

        // GET: productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_provedor = new SelectList(db.provedores, "id_provedor", "nombre_provedor", productos.id_provedor);
            return View(productos);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_produto,nombre_producto,precio,producto_cantidad,descripcion_producto,id_provedor")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_provedor = new SelectList(db.provedores, "id_provedor", "nombre_provedor", productos.id_provedor);
            return View(productos);
        }

        // GET: productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
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

        // GET: productos/Edit/5
        public ActionResult VentasProductos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_provedor = new SelectList(db.provedores, "id_provedor", "nombre_provedor", productos.id_provedor);
            return View(productos);
        }

        // POST: productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VentasProductos([Bind(Include = "id_produto,nombre_producto,precio,producto_cantidad,descripcion_producto,id_provedor")] productos productos, int Cantidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_provedor = new SelectList(db.provedores, "id_provedor", "nombre_provedor", productos.id_provedor);
            return View(productos);
        }
        //metodo para optener el precio por productos
        [HttpPost]
        public ActionResult PrecioVentas(int id_producto, int Cantidad)
        {
            var valor = (from produc in db.productos
                         where produc.id_produto == id_producto
                         select produc.precio).FirstOrDefault();

            int val = int.Parse(valor.ToString());
            return Content((val * Cantidad).ToString());
            
        }

    }
}
