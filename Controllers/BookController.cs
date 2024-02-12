using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(BooksEntity book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BooksEntity book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
