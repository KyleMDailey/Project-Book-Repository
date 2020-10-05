using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRepository.Models
{
    public interface IRepositoryRepository
    {
        IQueryable<Book> Books { get; }
    }
}
