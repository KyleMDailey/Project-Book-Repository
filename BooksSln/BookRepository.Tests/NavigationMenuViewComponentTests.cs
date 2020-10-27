using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using BookRepository.Components;
using BookRepository.Models;
using Xunit;

namespace BookRepository.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
                new Book {BookID = 1, Title = "B1", Category = "Apples"},
                new Book {BookID = 2, Title = "B2", Category = "Apples"},
                new Book {BookID = 3, Title = "B3", Category = "Plums"},
                new Book {BookID = 4, Title = "B4", Category = "Oranges"},
            }).AsQueryable<Book>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);

            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)(target.Invoke()
                as ViewViewComponentResult).ViewData.Model).ToArray();

            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples",
                "Oranges", "Plums" }, results));
        }
        [Fact]
        public void Indicates_Selected_Category()
        {
            // Arrange
            string categoryToSelect = "Apples";
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
                new Book {BookID = 1, Title = "P1", Category = "Apples"},
                new Book {BookID = 4, Title = "P2", Category = "Oranges"},
            }).AsQueryable<Book>());

            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };

            target.RouteData.Values["category"] = categoryToSelect;

            // Action
            string result = (string)(target.Invoke() as
                ViewViewComponentResult).ViewData["SelectedCategory"];

            // Assert
            Assert.Equal(categoryToSelect, result);
        }
    }
}