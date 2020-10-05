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
    }
}
