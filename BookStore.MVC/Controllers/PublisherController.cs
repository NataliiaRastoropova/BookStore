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
        public async Task<IActionResult> GetBooksList(int id)
        {
            var model = await m_bookService.GetByPublisher(id);
            return View(model);
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
            await m_publisherService.Create(collection);
            return RedirectToAction(nameof(Index));
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
            await m_publisherService.Update(collection);
            return RedirectToAction(nameof(Index));
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await m_publisherService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
