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
    public class Customers1Controller : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Customers1
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Product).Include(c => c.Empleyee).Include(c => c.Order);
            return View(customers.ToList());
        }

        // GET: Customers1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers1/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Products, "ProductID", "Title");
            ViewBag.CustomerID = new SelectList(db.Empleyees, "EmpleyeeID", "Name");
            ViewBag.CustomerID = new SelectList(db.Orders, "OrderID", "Title");
            return View();
        }

        // POST: Customers1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Products, "ProductID", "Title", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Orders, "OrderID", "Title", customer.CustomerID);
            return View(customer);
        }

        // GET: Customers1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Products, "ProductID", "Title", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Orders, "OrderID", "Title", customer.CustomerID);
            return View(customer);
        }

        // POST: Customers1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Products, "ProductID", "Title", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", customer.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Orders, "OrderID", "Title", customer.CustomerID);
            return View(customer);
        }

        // GET: Customers1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
