using Microsoft.AspNetCore.Mvc;
using BookRepository.Models;
using System.Linq;
using BookRepository.Models.ViewModels;

namespace BookRepository.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryRepository repository;

        public int PageSize = 4;

        public HomeController(IRepositoryRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int bookPage = 1)
            => View(new BooksListViewModel
            {
                Books = repository.Books
                    .Where(b => category == null || b.Category == category)
                    .OrderBy(b => b.BookID)
                    .Skip((bookPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Books.Count() :
                        repository.Books.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
