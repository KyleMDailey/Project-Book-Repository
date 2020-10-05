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

        public ViewResult Index(int bookPage = 1)
            => View(new BooksListViewModel
            {
                Books = repository.Books
                    .OrderBy(b => b.BookID)
                    .Skip((bookPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Books.Count()
                }
           });
    }
}
