using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Morris_Isaac_Homework7.Infrastructure;
using Morris_Isaac_Homework7.Models;

namespace Morris_Isaac_Homework7.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBooklistRepository repository;
        public PurchaseModel(IBooklistRepository repo, Cart CartService)
        {
            repository = repo;
            Cart = CartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(p => p.BookId == BookId);

            Cart.AddItem(book, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == BookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
