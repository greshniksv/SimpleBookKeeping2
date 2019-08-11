using System.Threading;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Common.Requests.Users;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;
using Xunit;

namespace SimpleBookKeeping.CommonTests
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
            var user = new User() { Id = userDto.UserId };

            mapper.Setup(x => x.Map<User, UserDto>(It.IsAny<User>()))
                .Returns(userDto);

            context.Users.Add(user);
            context.SaveChanges();

            GetUserHandler handler = new GetUserHandler(context, mapper.Object);
            var result = handler.Handle(new GetUser(1), CancellationToken.None).Result;

            Assert.NotNull(result);
            Assert.Equal(result.UserId, user.Id);
        }
    }
}
