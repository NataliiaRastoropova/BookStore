using System;
using System.Threading.Tasks;
using BookStore.Shared.Dto.Publisher;
using BookStore.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MVC.Controllers
{
    public class PublisherController : Controller
    {
        private readonly PublisherService m_publisherService;
        private readonly BookService m_bookService;

        public PublisherController(PublisherService publisherService, BookService bookService)
        {
            m_publisherService = publisherService;
            m_bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await m_publisherService.GetAll();
            return View(model);
        }

        [HttpGet] //todo: move to BooksController
        public async Task<IActionResult> BooksList(int id)
        {
            try
            {
                var model = await m_bookService.GetByPublisher(id);
                return View(model);
                //return RedirectToAction("BooksList", "Book", model);
            }
            catch(Exception ex)
            {
                var w = ex.ToString();
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherCreateModel collection)
        {
            if (ModelState.IsValid)
            {
                await m_publisherService.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(collection);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await m_publisherService.GetById(id);
            return View(model);
        }

        [HttpPost]
        // [httpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PublisherEditModel collection)
        {
            if (ModelState.IsValid)
            {
                await m_publisherService.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(collection);
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await m_publisherService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
