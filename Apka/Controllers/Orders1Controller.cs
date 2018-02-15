using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace Apka.Controllers
{
    public class Orders1Controller : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Orders1
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Empleyee).Include(o => o.Product).Include(o => o.Sell);
            return View(orders.ToList());
        }

        // GET: Orders1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders1/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.OrderID = new SelectList(db.Empleyees, "EmpleyeeID", "Name");
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "Title");
            ViewBag.OrderID = new SelectList(db.Sells, "SellID", "SellID");
            return View();
        }

        // POST: Orders1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,Title,Time")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Customers, "CustomerID", "FirstName", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "Title", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Sells, "SellID", "SellID", order.OrderID);
            return View(order);
        }

        // GET: Orders1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Customers, "CustomerID", "FirstName", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "Title", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Sells, "SellID", "SellID", order.OrderID);
            return View(order);
        }

        // POST: Orders1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,Title,Time")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Customers, "CustomerID", "FirstName", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Products, "ProductID", "Title", order.OrderID);
            ViewBag.OrderID = new SelectList(db.Sells, "SellID", "SellID", order.OrderID);
            return View(order);
        }

        // GET: Orders1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
