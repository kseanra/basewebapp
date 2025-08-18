using Xunit;
using Moq;
using basicapi.Domain.Entities;
public class GetUserByIdHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly GetUserByIdHandler _handler;

    public GetUserByIdHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new GetUserByIdHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Name = "Test User", Email = "testuser@example.com" };

        _userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(user);

        // Act
        var result = await _handler.Handle(new GetUserByIdQuery(userId), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test User", result.Name);
        Assert.Equal("testuser@example.com", result.Email);

        _userRepositoryMock.Verify(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()), Times.Once);
    }
}
