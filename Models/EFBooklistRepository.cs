using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morris_Isaac_Homework7.Models
{
    public class EFBooklistRepository : IBooklistRepository
    {
        private BooklistDbContext _context;
        //constructor
        public EFBooklistRepository(BooklistDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
