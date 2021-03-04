using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Morris_Isaac_Homework7.Models;
using Morris_Isaac_Homework7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBooklistRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBooklistRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page=1)
        {
            return View(new BookListViewModel
            {
                //Display all books according to category passed in by user
                Books = _repository.Books
                .Where(p => category == null || p.Category == category)
                .OrderBy(page => page.BookId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                ,
                //Generate pages based on category passed in. Get count of books of that category
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
