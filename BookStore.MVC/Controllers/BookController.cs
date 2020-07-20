using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.MVC.Models;
using BookStore.Shared.Dto.Book;
using BookStore.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService m_bookService;
        private readonly PublisherService m_publisherService;

        public BookController(BookService bookService, PublisherService publisherService)
        {
            m_bookService = bookService;
            m_publisherService = publisherService;
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
                // add error view ViewBag[]
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = (await m_publisherService.GetAll())
                        .Select(x => new SelectListItem
                        {
                            Text = x.Name,
                            Value = x.Id.ToString()
                        }).ToList();
          
            ViewBag.PublishersList = model;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateModel collection)
        {
            try
            {
                await m_bookService.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // add error view ViewBag[]
                var error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publishersModel = (await m_publisherService.GetAll())
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.PublishersList = publishersModel;

            var model = m_bookService.GetById(id);
            return View(model);
        }

        //[HttpPut]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookEditModel collection)
        {
            try
            {
                await m_bookService.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // add error view ViewBag[]
                return View();
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
            catch (Exception ex)
            {
                // add error view ViewBag[]
                return View();
            }
        }
    }
}
