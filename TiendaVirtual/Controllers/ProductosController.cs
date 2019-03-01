using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class ProductosController : Controller
    {
        private ModeloTiendaVirtualContainer db = new ModeloTiendaVirtualContainer();

        [Authorize]
        public ActionResult AddToCart(CarritoPedidos pedido, int id)
        {
            int numProds = 0;
            pedido.ForEach(prod =>
            {
                if (prod.Id == id)
                {
                    numProds++;
                }
            });
            Productos selectedProduct = db.Productos.Find(id);

            if(numProds < selectedProduct.Cantidad)
            {
                pedido.Add(db.Productos.Find(id));
            }
            
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        [Authorize]
        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        [Authorize(Users = "admin@gamewarriors.com")]
        // password -> *Admin1*
        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Users = "admin@gamewarriors.com")]
        // password -> *Admin1*
        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Precio,Cantidad,Imagen")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productos);
        }

        [Authorize(Users = "admin@gamewarriors.com")]
        // password -> *Admin1*
        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        [Authorize(Users = "admin@gamewarriors.com")]
        // password -> *Admin1*
        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,Cantidad,Imagen")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productos);
        }

        [Authorize(Users = "admin@gamewarriors.com")]
        // password -> *Admin1*
        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        [Authorize(Users = "admin@gamewarriors.com")]
        // password -> *Admin1*
        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
