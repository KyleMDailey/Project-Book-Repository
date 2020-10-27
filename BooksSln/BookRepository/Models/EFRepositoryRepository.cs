using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Models
{
    public class EFRepositoryRepository : IRepositoryRepository
    {
        private RepositoryDBContext context;

        public EFRepositoryRepository(RepositoryDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Book> Books => context.Books;

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }
    }
}
