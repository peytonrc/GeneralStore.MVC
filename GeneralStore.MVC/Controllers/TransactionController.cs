using FormFactory;
using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            return View(_db.Transactions.ToList());
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(_db.Customers, "CustomerId", "FullName");
            ViewBag.ProductID = new SelectList(_db.Products, "ProductId", "Name");
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var product = _db.Products.Find(transaction.ProductId);
                if (product.InventoryCount < 1)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                product.InventoryCount--;

                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName", transaction.CustomerId);
            ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name", transaction.ProductId);

            return View(transaction);
        }

        // GET: Transaction/Delete{id}
        public ActionResult Delete(int? id) //int? means it is a boxed integer value; it is nullable
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) // Create Delete Method that takes in an ID
        {
            Transaction transaction = _db.Transactions.Find(id); // Create an instance of Product and set it = to the database of Products and find it by the ID
            _db.Transactions.Remove(transaction); // Go to database Products and remove that instance of the Product (product)
            _db.SaveChanges(); // Save Changes to database
            return RedirectToAction("Index"); // After complete, redirect back to Index page
        }

        // GET: Transaction/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transaction).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Product/Details{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

    }
}
