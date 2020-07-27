using System.Threading.Tasks;
using BookStore.Shared.Dto.Author;
using BookStore.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService m_authorService;
        private readonly BookService m_bookService;

        public AuthorController(AuthorService authorService, BookService bookService)
        {
            m_authorService = authorService;
            m_bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await m_authorService.GetAll();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksList(int id)
        {
            try
            {
                var model = await m_bookService.GetByPublisher(id);
                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateModel collection)
        {
            if (ModelState.IsValid)
            {
                await m_authorService.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(collection);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await m_authorService.GetById(id);
            model.Birthday = model.Birthday.Date;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuthorEditModel collection)
        {
            if (ModelState.IsValid)
            { 
                await m_authorService.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(collection);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await m_authorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
