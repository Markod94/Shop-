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
    public class EmpleyeesController : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Empleyees
        public ActionResult Index()
        {
            var empleyees = db.Empleyees.Include(e => e.Customer).Include(e => e.Order).Include(e => e.Product).Include(e => e.Sell);
            return View(empleyees.ToList());
        }

        // GET: Empleyees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleyee empleyee = db.Empleyees.Find(id);
            if (empleyee == null)
            {
                return HttpNotFound();
            }
            return View(empleyee);
        }

        // GET: Empleyees/Create
        public ActionResult Create()
        {
            ViewBag.EmpleyeeID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.EmpleyeeID = new SelectList(db.Orders, "OrderID", "Title");
            ViewBag.EmpleyeeID = new SelectList(db.Products, "ProductID", "Title");
            ViewBag.EmpleyeeID = new SelectList(db.Sells, "SellID", "SellID");
            return View();
        }

        // POST: Empleyees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleyeeID,Name,LastName,SellID,Gender,Salary")] Empleyee empleyee)
        {
            if (ModelState.IsValid)
            {
                db.Empleyees.Add(empleyee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleyeeID = new SelectList(db.Customers, "CustomerID", "FirstName", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Orders, "OrderID", "Title", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Products, "ProductID", "Title", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Sells, "SellID", "SellID", empleyee.EmpleyeeID);
            return View(empleyee);
        }

        // GET: Empleyees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleyee empleyee = db.Empleyees.Find(id);
            if (empleyee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleyeeID = new SelectList(db.Customers, "CustomerID", "FirstName", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Orders, "OrderID", "Title", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Products, "ProductID", "Title", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Sells, "SellID", "SellID", empleyee.EmpleyeeID);
            return View(empleyee);
        }

        // POST: Empleyees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleyeeID,Name,LastName,SellID,Gender,Salary")] Empleyee empleyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleyee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleyeeID = new SelectList(db.Customers, "CustomerID", "FirstName", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Orders, "OrderID", "Title", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Products, "ProductID", "Title", empleyee.EmpleyeeID);
            ViewBag.EmpleyeeID = new SelectList(db.Sells, "SellID", "SellID", empleyee.EmpleyeeID);
            return View(empleyee);
        }

        // GET: Empleyees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleyee empleyee = db.Empleyees.Find(id);
            if (empleyee == null)
            {
                return HttpNotFound();
            }
            return View(empleyee);
        }

        // POST: Empleyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleyee empleyee = db.Empleyees.Find(id);
            db.Empleyees.Remove(empleyee);
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
