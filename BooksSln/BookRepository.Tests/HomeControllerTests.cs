using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BookRepository.Controllers;
using BookRepository.Models;
using Xunit;
using BookRepository.Models.ViewModels;

namespace BookRepository.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Use_Repository()
        {
            // Arrange
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
                new Book {BookID = 1, Title = "B1"},
                new Book {BookID = 2, Title = "B2"}
            }).AsQueryable<Book>());

            HomeController controller = new HomeController(mock.Object);

            // Act
            BooksListViewModel result =
                controller.Index().ViewData.Model as BooksListViewModel;

            // Assert
            Book[] bookArray = result.Books.ToArray();
            Assert.True(bookArray.Length == 2);
            Assert.Equal("B1", bookArray[0].Title);
            Assert.Equal("B2", bookArray[1].Title);
        }
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
                new Book {BookID = 1, Title = "B1"},
                new Book {BookID = 2, Title = "B2"},
                new Book {BookID = 3, Title = "B3"},
                new Book {BookID = 4, Title = "B4"},
                new Book {BookID = 5, Title = "B5"}
            }).AsQueryable<Book>());

            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            // Act
            BooksListViewModel result =
                controller.Index(2).ViewData.Model as BooksListViewModel;

            // Assert
            Book[] prodArray = result.Books.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("B4", prodArray[0].Title);
            Assert.Equal("B5", prodArray[1].Title);
        }
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
                new Book {BookID = 1, Title = "B1"},
                new Book {BookID = 2, Title = "B2"},
                new Book {BookID = 3, Title = "B3"},
                new Book {BookID = 4, Title = "B4"},
                new Book {BookID = 5, Title = "B5"}
            }).AsQueryable<Book>());

            // Arrange
            HomeController controller =
            new HomeController(mock.Object) { PageSize = 3 };

            // Act
            BooksListViewModel result =
            controller.Index(2).ViewData.Model as BooksListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}