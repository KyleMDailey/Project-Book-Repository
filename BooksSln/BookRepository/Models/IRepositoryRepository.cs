using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Models
{
    public interface IRepositoryRepository
    {
        IQueryable<Book> Books { get; }

        void SaveBook(Book b);
        void CreateBook(Book b);
        void DeleteBook(Book b);
    }
}
