using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Database;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private BooksRepository _booksRepository = new BooksRepository();

        public IActionResult Index()
        {
            ViewBag.Genres = new GenreRepository().GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var booksList = _booksRepository.GetBooks();
            

            return View(booksList);
        }

        public IActionResult Details(int id)
        {
            return View(_booksRepository.GetBookById(id));
        }

        public IActionResult Create()
        {
            
            ViewBag.Genres = new GenreRepository().GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
          if (ModelState.IsValid)
            {
                
                var newBookId = _booksRepository.AddBook(book);
                return RedirectToAction("Details", new { id = newBookId });
            }
            ViewBag.Genres = new GenreRepository().GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(book);
        }

        
        public IActionResult Edit(int id)
        {

            ViewBag.Genres = new GenreRepository().GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(_booksRepository.GetBookById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                var newBookId = _booksRepository.EditBook(id, book);
                return RedirectToAction("Details", new { id = newBookId });
            }
            ViewBag.Genres = new GenreRepository().GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View(book);
        }

        
        public IActionResult Delete(int id)
        {
            var newBookId = _booksRepository.DeleteBook(id);
            return RedirectToAction("Index");
        }



        public IActionResult BooksList(int? genreId)
        {
            if (genreId.HasValue)
            {
                var model = _booksRepository.GetBookByGenreId(genreId.Value);
                return PartialView("_BooksList", model);
            }
            return PartialView("_BooksList");
        }

        
    }
}