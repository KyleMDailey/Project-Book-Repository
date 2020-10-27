using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BookRepository.Controllers;
using BookRepository.Models;
using Xunit;
using BookRepository.Models.ViewModels;
using System;

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
                controller.Index(null).ViewData.Model as BooksListViewModel;

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
                controller.Index(null, 2).ViewData.Model as BooksListViewModel;

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
                controller.Index(null, 2).ViewData.Model as BooksListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
        [Fact]
        public void Can_Filter_Books()
        {
            //Arrange
            //create the mock repository
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[]
            {
                new Book {BookID = 1, Title = "B1", Category = "Cat1" },
                new Book {BookID = 2, Title = "B2", Category = "Cat2" },
                new Book {BookID = 3, Title = "B3", Category = "Cat1" },
                new Book {BookID = 4, Title = "B4", Category = "Cat2" },
                new Book {BookID = 5, Title = "B5", Category = "Cat3" }
            }).AsQueryable<Book>());

            //Arrange - create a controller and make the page size 3 items
            HomeController controller = new HomeController(mock.Object);
            controller.PageSize = 3;

            //Action
            Book[] result =
                (controller.Index("Cat2, 1").ViewData.Model as BooksListViewModel)
                    .Books.ToArray();

            //Assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Title == "B2" && result[0].Category == "Cat2");
            Assert.True(result[1].Title == "B4" && result[0].Category == "Cat2");
        }
        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            Mock<IRepositoryRepository> mock = new Mock<IRepositoryRepository>();
            mock.Setup(m => m.Books).Returns((new Book[] {
                new Book {BookID = 1, Title = "P1", Category = "Cat1"},
                new Book {BookID = 2, Title = "P2", Category = "Cat2"},
                new Book {BookID = 3, Title = "P3", Category = "Cat1"},
                new Book {BookID = 4, Title = "P4", Category = "Cat2"},
                new Book {BookID = 5, Title = "P5", Category = "Cat3"}
            }).AsQueryable<Book>());

            HomeController target = new HomeController(mock.Object);
            target.PageSize = 3;

            Func<ViewResult, BooksListViewModel> GetModel = result =>
                result?.ViewData?.Model as BooksListViewModel;

            // Action
            int? res1 = GetModel(target.Index("Cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.Index("Cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.Index("Cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.Index(null))?.PagingInfo.TotalItems;

            // Assert
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }
    }
}