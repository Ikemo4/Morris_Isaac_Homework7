using Microsoft.AspNetCore.Mvc;
using Morris_Isaac_Homework7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework7.Components
{
    //NavigationMenu View Component to display filtered results by Book Category to user
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBooklistRepository repository;

        public NavigationMenuViewComponent (IBooklistRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            //Select all distinct categories from books in database and display in Navigation Menu
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
