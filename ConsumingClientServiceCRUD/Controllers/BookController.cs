using ConsumingClientServiceCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumingClientServiceCRUD.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        ServiceReference5.Book b = new ServiceReference5.Book();
        ServiceReference5.BookServicesClient mbsClient = new ServiceReference5.BookServicesClient();
        public ActionResult Index()
        {
            ViewBag.listBooks = mbsClient.GetBookList();
            return View();

        }

        public ActionResult Create(string title, string isbn)
        {
            mbsClient.AddBook(new ServiceReference5.Book() { Title = title, ISBN = isbn });
            return RedirectToAction("Index");
        }

        public ActionResult Update(string title, string isbn, int bookId)
        {
            mbsClient.UpdateBook(new ServiceReference5.Book() { Title = title, ISBN = isbn, BookId = bookId },bookId.ToString());
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int bookId)
        {
            var book = mbsClient.GetBookById(bookId.ToString());
            ViewBag.book = book;
            return View();
        }

        public ActionResult Delete(int bookId)
        {
            mbsClient.DeleteBook(bookId.ToString());
            return RedirectToAction("Index");
        }
    }
}