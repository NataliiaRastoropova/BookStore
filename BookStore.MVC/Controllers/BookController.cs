using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Shared.Dto.Book;
using BookStore.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService m_bookService;
        private readonly PublisherService m_publisherService;
        public readonly AuthorService m_authorService;

        public BookController(BookService bookService, PublisherService publisherService, AuthorService authorService)
        {
            m_bookService = bookService;
            m_publisherService = publisherService;
            m_authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await m_bookService.GetAll();
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> BooksList(IEnumerable<BookViewModel> model)
        //{
        //    try
        //    {
        //        return View(model);
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.PublishersList = await GetPublishersSelectList();
            ViewBag.AuthorsList = await GetAuthorsSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateModel collection)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                await m_bookService.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.PublishersList = await GetPublishersSelectList();
                ViewBag.AuthorsList = await GetAuthorsSelectList();

                return View(collection);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.PublishersList = await GetPublishersSelectList();
            ViewBag.AuthorsList = await GetAuthorsSelectList();

            var model = await m_bookService.GetById(id);
            return View(model);
        }

        //[HttpPut]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookEditModel collection)
        {
            if (ModelState.IsValid)
            {
                await m_bookService.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.PublishersList = await GetPublishersSelectList();
                ViewBag.AuthorsList = await GetAuthorsSelectList();
                return View(collection);
            }
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await m_bookService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task<List<SelectListItem>> GetPublishersSelectList()
        {
            var publishers = (await m_publisherService.GetAll())
                                .Select(p => new SelectListItem
                                {
                                    Text = p.Name,
                                    Value = p.Id.ToString()
                                }).ToList();

            return publishers;
        }

        private async Task<List<SelectListItem>> GetAuthorsSelectList()
        {
            var authors = (await m_authorService.GetAll())
                                .Select(a => new SelectListItem
                                {
                                    Text = a.FullName,
                                    Value = a.Id.ToString()
                                }).ToList();
            return authors;
        }
    }
}
