using GeneralStore.MVC.Models;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class ProductController : Controller
    {
        // Add the application DB Context (link to the database)
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            List<Product> productList = _db.Products.ToList();
            List<Product> orderedList = productList.OrderBy(product => product.Name).ToList();
            return View(orderedList);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index"); // Redirect tells ASP.NET MVC to repsond with a Browser redirect to a different action instead of rendering HTML
            }

            return View(product); // Return View tells MVC to generate HTML to be displayed and sends it to the browser 
        }

        // GET: Product/Delete{id}
        public ActionResult Delete(int? id) //int? means it is a boxed integer value; it is nullable
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) // Create Delete Method that takes in an ID
        {
            Product product = _db.Products.Find(id); // Create an instance of Product and set it = to the database of Products and find it by the ID
            _db.Products.Remove(product); // Go to database Products and remove that instance of the Product (product)
            _db.SaveChanges(); // Save Changes to database
            return RedirectToAction("Index"); // After complete, redirect back to Index page
        }

        //// GET: Product/Edit/{id}
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = _db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //// POST: Product/Edit/{id}
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Product product)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _db.Entry(product).State = EntityState.Modified;
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        // GET: Product/Details{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}