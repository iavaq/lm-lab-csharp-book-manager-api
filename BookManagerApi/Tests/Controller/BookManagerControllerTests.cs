using BookManagerApi.Controllers;
using BookManagerApi.Models;
using BookManagerApi.Services;
using NUnit.Framework;
using Moq;


namespace BookManagerApi.Tests.Controller
{
    public class BookManagerControllerTests
    {
        private BookManagerController _controller;
        private Mock<IBookManagementService> _mockService;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IBookManagementService>();
            _controller = new BookManagerController(_mockService.Object);
        }

        private static List<Book> TestBooks()
        {
            return new List<Book>
            {
                new Book() { Id = 1, Title = "Book One", Description = "This is the description for Book One", Author = "Person One", Genre = Genre.Education },
                new Book() { Id = 2, Title = "Book Two", Description = "This is the description for Book Two", Author = "Person Two", Genre = Genre.Fantasy },
                new Book() { Id = 3, Title = "Book Three", Description = "This is the description for Book Three", Author = "Person Three", Genre = Genre.Thriller },
            };
        }
        [Test]
        public void GetBooksShouldReturnAllBooks()
        {
            // Arrange
            _mockService.Setup(x => x.GetAllBooks()).Returns(TestBooks());

            // Act 
            var result = _controller.GetBooks();

            // Assert
            Assert.That(result, Is.InstanceOf<IEnumerable<Book>>());
            Assert.That(result.Value.Count, Is.EqualTo(TestBooks().Count));
            Assert.That(result.Value, Is.EquivalentTo(TestBooks()));
            
        }
    }
}
