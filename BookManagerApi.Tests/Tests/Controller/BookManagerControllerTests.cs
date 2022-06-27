using BookManagerApi.Controllers;
using BookManagerApi.Models;
using BookManagerApi.Services;
using NUnit.Framework;
using Moq;


namespace BookManagerApi.Tests.Controller
{
    public class BookManagerControllerTests
    {
        private readonly BookManagerController _controller;
        private readonly Mock<IBookManagementService> _service;

        public BookManagerControllerTests()
        {
            _service = new Mock<IBookManagementService>();
            _controller = new BookManagerController(_service.Object);
        }

        [Test]
        public void TestGetBookNoParams()
        {

            // Act 
            var result = _controller.GetBooks();

            // Assert
            Assert.IsInstanceOf<Book>(result.Result);

            
        }
    }
}
