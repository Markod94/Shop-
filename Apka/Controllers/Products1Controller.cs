﻿using System;
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
    public class Products1Controller : Controller
    {
        private ShopEntities db = new ShopEntities();

        // GET: Products1
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Customer).Include(p => p.Empleyee).Include(p => p.Order);
            return View(products.ToList());
        }

        // GET: Products1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products1/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.ProductID = new SelectList(db.Empleyees, "EmpleyeeID", "Name");
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "Title");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Title,Description,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Customers, "CustomerID", "FirstName", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "Title", product.ProductID);
            return View(product);
        }

        // GET: Products1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Customers, "CustomerID", "FirstName", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "Title", product.ProductID);
            return View(product);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Title,Description,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Customers, "CustomerID", "FirstName", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Empleyees, "EmpleyeeID", "Name", product.ProductID);
            ViewBag.ProductID = new SelectList(db.Orders, "OrderID", "Title", product.ProductID);
            return View(product);
        }

        // GET: Products1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
