using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookRepository.Models;

namespace BookRepository.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IRepositoryRepository repository;

        public NavigationMenuViewComponent(IRepositoryRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
