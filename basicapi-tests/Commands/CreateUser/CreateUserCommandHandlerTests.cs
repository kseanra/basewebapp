using Moq;
using Xunit;
using AutoMapper;
using basicapi.Domain.Entities;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly IMapper _mapper;
    private readonly CreateUserHandler _handler;

    public CreateUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _mapper = new Mock<IMapper>().Object;
        _handler = new CreateUserHandler(_userRepositoryMock.Object, _mapper);
    }
        
    [Fact]
    public async Task Handle_ShouldCreateUser_WhenValidCommand()
    {
        // Arrange
        var command = new CreateUserCommand
        {
            Name = "Test User",
            Email = "testuser@example.com"
        };

        _userRepositoryMock.Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask).Verifiable();

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _userRepositoryMock.Verify(repo => repo.CreateUserAsync(It.IsAny<User>()), Times.Once);
    }
}