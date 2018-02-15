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
    public class Sells1Controller : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Sells1
        public ActionResult Index()
        {
            var sells = db.Sells.Include(s => s.Customer).Include(s => s.Empleyee).Include(s => s.Order).Include(s => s.Product);
            return View(sells.ToList());
        }

        // GET: Sells1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // GET: Sells1/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.SellID = new SelectList(db.Empleyees, "EmpleyeeID", "Name");
            ViewBag.SellID = new SelectList(db.Orders, "OrderID", "Title");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title");
            return View();
        }

        // POST: Sells1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SellID,CustomerID,ProductID,DateSell")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                db.Sells.Add(sell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", sell.CustomerID);
            ViewBag.SellID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", sell.SellID);
            ViewBag.SellID = new SelectList(db.Orders, "OrderID", "Title", sell.SellID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", sell.ProductID);
            return View(sell);
        }

        // GET: Sells1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", sell.CustomerID);
            ViewBag.SellID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", sell.SellID);
            ViewBag.SellID = new SelectList(db.Orders, "OrderID", "Title", sell.SellID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", sell.ProductID);
            return View(sell);
        }

        // POST: Sells1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SellID,CustomerID,ProductID,DateSell")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", sell.CustomerID);
            ViewBag.SellID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", sell.SellID);
            ViewBag.SellID = new SelectList(db.Orders, "OrderID", "Title", sell.SellID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Title", sell.ProductID);
            return View(sell);
        }

        // GET: Sells1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return HttpNotFound();
            }
            return View(sell);
        }

        // POST: Sells1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sell sell = db.Sells.Find(id);
            db.Sells.Remove(sell);
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
