using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework7.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book b, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == b.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = b,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book b) =>
            Lines.RemoveAll(x => x.Book.BookId == b.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum()
        {
            return Lines.Sum(e => Convert.ToDecimal(e.Quantity)* Convert.ToDecimal(e.Book.Price));
        }

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
