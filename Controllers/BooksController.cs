using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapLap4.Models;

namespace BaiTapLap4.Controllers
{
    public class BooksController : Controller
    {
        private ModelManager db = new ModelManager();

        // GET: Books
        public ActionResult ListBook()
        {
            return View(db.Books.ToList());
        }
        [Authorize]
        public ActionResult Buy(string id)
        {
            var book = db.Books.FirstOrDefault(p => p.Id.Equals(id));
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Arthor,Title,Description,ImageCover,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("ListBook");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Arthor,Title,Description,ImageCover,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(book).State = EntityState.Modified;
                //db.SaveChanges();
                Book dbUpdate = db.Books.FirstOrDefault(p => p.Id.Equals(book.Id) );
                if (dbUpdate != null)
                {
                    db.Books.AddOrUpdate(book); //Add or Update Book b 
                    db.SaveChanges();
                }
                return RedirectToAction("ListBook");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("ListBook");
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
