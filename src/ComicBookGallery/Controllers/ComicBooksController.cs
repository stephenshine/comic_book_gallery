using ComicBookGallery.Data;
using ComicBookGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComicBookGallery.Controllers
{
    public class ComicBooksController : Controller
    {
        private ComicBookRepository _comicBookRepository = null;

        public ComicBooksController()
        {
            _comicBookRepository = new ComicBookRepository();
        }

        public ActionResult Index()
        {
            var comicBooks = _comicBookRepository.GetComicBooks();

            return View(comicBooks);
        }

        //int? makes argument nullable (optional)
        public ActionResult Detail(int? id)
        {
            //returns 404 error if input is null
            if (id == null)
            {
                return HttpNotFound();
            }

            //need to use id.Value to get at value in an optional attribute
            var comicBook = _comicBookRepository.GetCommicBook(id.Value);

            //Goes out to run ComicBooks.cs
            return View(comicBook);
        }
    }
}