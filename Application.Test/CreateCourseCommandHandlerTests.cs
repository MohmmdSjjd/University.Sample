using Application.Dtos.Course.Commands;
using Application.Features.Commands.Course.Create;
using AutoMapper;
using Domain.Contracts.Repositories;
using Domain.Entities;
using Domain.Exceptions;
using Moq;
using Xunit.Abstractions;

namespace Application.Test
{
    public class CreateCourseCommandHandlerTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateCourseCommandHandler _handler;

        public CreateCourseCommandHandlerTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _mockCourseRepository = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateCourseCommandHandler(_mockCourseRepository.Object, _mockMapper.Object);
        }


        [Fact]
        public async Task Handle_ValidRequest_ShouldReturnCourseId()
        {
            // Arrange
            var command = new CreateCourseCommand
            {
                Name = "Test Course",
                Code = "TC01"
            };

            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Code = command.Code
            };

            var responseDto = new CreateCourseCommandResponseDto
            {
                Id = course.Id
            };

            _mockMapper.Setup(m => m.Map<Course>(command)).Returns(course);
            _mockCourseRepository.Setup(repo => repo.AddAsync(course)).ReturnsAsync(course);
            _mockMapper.Setup(m => m.Map<CreateCourseCommandResponseDto>(course)).Returns(responseDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Log the result
            _testOutputHelper.WriteLine($"Result: {result?.Id}");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(course.Id, result.Id);
        }

        [Fact]
        public async Task Handle_FailedToCreateCourse_ShouldThrowApiException()
        {
            // Arrange
            var command = new CreateCourseCommand
            {
                Name = "Test Course",
                Code = "TC01"
            };

            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Code = command.Code
            };

            _mockMapper.Setup(m => m.Map<Course>(command)).Returns(course);
            _mockCourseRepository.Setup(repo => repo.AddAsync(course)).ReturnsAsync((Course)null);

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}