using baitap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitap2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher()
        {
            return "Hello Nguyen Thanh Dat";
        }
        public string HelloTeacher(string university)
        {
            return "Hello Nguyen Thanh Dat - University:" + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML & CSS3 The Complete Manaul - Author Book 1");
            books.Add("HTML & CSS Responsive web Design cookbook -  - Author Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"HTML5 & CSS3 The complete Manual","Author Name Book 1","/Content/Images/hinh1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookbook", "Author Name Book 2","/Content/Images/hinh2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 ", "Author Name Book 3","/Content/Images/hinh3.jpg"));
            
            return View(books);
        }


        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", " Author Name Book 1 ", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookcook ", " Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 - Author Name Book 2", "Author Name Book 3", "/Content/images/book3.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if(b.Id==id)
                {
                    book = b;
                    break;
                }
            }
            if (book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", " Author Name Book 1 ", "/Content/images/book1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookcook ", " Author Name Book 2", "/Content/images/book2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 - Author Name Book 2", "Author Name Book 3", "/Content/images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

    }
}