using lap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace VNExpress.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "hellloooo mn - University: "+ university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Reponsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/image/IMG_7921.JPG"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/image/IMG_7922.JPG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/image/IMG_7926.JPG"));
            return View(books);
        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/image/IMG_7921.JPG"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/image/IMG_7922.JPG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/image/IMG_7926.JPG"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]

        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/image/IMG_7921.JPG"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/image/IMG_7922.JPG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/image/IMG_7926.JPG"));
            if (id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/image/IMG_7921.JPG"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/image/IMG_7922.JPG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/image/IMG_7926.JPG"));
            try
            {
                if (ModelState.IsValid)
                {
                    //Them sach
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }

            return View("ListBookModel", books);
        }

        public ActionResult DeleteBook(int Id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/image/IMG_7921.JPG"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/image/IMG_7922.JPG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/image/IMG_7926.JPG"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryTokenAttribute]
        public ActionResult Delete(int Id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "/Content/image/IMG_7921.JPG"));
            books.Add(new Book(2, "HTML5 & CSS Reponsive web Design cookbook", "Author Name Book 2", "/Content/image/IMG_7922.JPG"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 2", "/Content/image/IMG_7926.JPG"));
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    books.Remove(b);
                    break;
                }
            }
            return View("ListBookModel", books);
        }
    }
}