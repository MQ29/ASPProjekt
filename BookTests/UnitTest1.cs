using ASPProjekt.Controllers;
using ASPProjekt.Models;
using BookData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Xunit;

namespace BookTests
{
    public class BookControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithListOfBooks()
        {
            // Arrange
            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.FindAll()).Returns(new List<Book>());

            var controller = new BookController(mockBookService.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
            Assert.NotNull(result.Model);
            Assert.IsType<List<Book>>(result.Model);
        }

        [Fact]
        public void Create_Get_ReturnsViewWithBookModelAndPublishersList()
        {
            // Arrange
            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(service => service.FindAllPublishers()).Returns(new List<PublisherEntity>());

            var controller = new BookController(mockBookService.Object);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Create", result.ViewName);
            Assert.NotNull(result.Model);
            Assert.IsType<Book>(result.Model);

            var model = result.Model as Book;
            Assert.NotNull(model.PublisherList);
            Assert.IsType<List<SelectListItem>>(model.PublisherList);
        }

        [Fact]
        public void Create_Post_WithValidModel_RedirectsToIndex()
        {
            // Arrange
            var mockBookService = new Mock<IBookService>();
            var controller = new BookController(mockBookService.Object);
            var validBook = new Book { /* populate with valid data */ };

            // Act
            var result = controller.Create(validBook) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Update_Get_ReturnsViewWithBookModel()
        {
            // Arrange
            var mockBookService = new Mock<IBookService>();
            var controller = new BookController(mockBookService.Object);
            int bookId = 1;

            mockBookService.Setup(service => service.FindById(bookId)).Returns(new Book { /* populate with sample data */ });

            // Act
            var result = controller.Update(bookId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Update", result.ViewName);
            Assert.NotNull(result.Model);
            Assert.IsType<Book>(result.Model);
        }

        [Fact]
        public void CreatePublisher_Get_ReturnsView()
        {
            // Arrange
            var mockBookService = new Mock<IBookService>();
            var controller = new BookController(mockBookService.Object);

            // Act
            var result = controller.CreatePublisher() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("CreatePublisher", result.ViewName);
        }

    }
}