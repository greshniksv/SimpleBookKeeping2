using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Common.DTOs;
using Common.Requests.Users;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CommonTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var builder = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("TempDatabase");

            var context = new DatabaseContext(builder.Options);
            var mapper = new Mock<IMapper>();
            var userDto = fixture.Create<UserDto>();
            var user = new User() { UserId = userDto.UserId };

            mapper.Setup(x => x.Map<User, UserDto>(It.IsAny<User>()))
                .Returns(userDto);

            context.Users.Add(user);
            context.SaveChanges();

            GetUserHandler handler = new GetUserHandler(context, mapper.Object);
            var result = handler.Handle(new GetUser { UserId = 1 }, CancellationToken.None).Result;

            Assert.NotNull(result);
            Assert.Equal(result.UserId, user.UserId);
        }
    }
}
