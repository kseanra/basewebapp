using Xunit;
using Moq;
using basicapi.Controllers;
using basicapi.Models;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using basicapi.Models;

namespace basicapi_tests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task CreateUser_ReturnsCreatedAtActionResult_WhenValidRequest()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var mapperMock = new Mock<IMapper>();
            var controller = new UserController(mediatorMock.Object, mapperMock.Object);
            var userRequest = new basicapi.Models.UserRequest { Name = "Test User", Email = "test@example.com" };

            mediatorMock.Setup(m => m.Send(It.IsAny<object>(), default)).ReturnsAsync(Unit.Value);

            // Act
            var result = await controller.CreateUser(userRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Test User", createdResult.Value);
        }
    }
}
