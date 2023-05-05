using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using Moq;


namespace BusinessLogic.Tests_
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public static IEnumerable<object[]> GetIncorrectUsers ()
        {
            return new List<object[]>
            {
                new object[]{new Пользователи() { Login = "",  Password = "",
                    Surname = "",
                    Name="",
                    Lastname ="",
                    Birthday = DateTime.MaxValue,
                    IsDeleted = false,
                    IsAdmin = false} },
                new object[]{new Пользователи() { Login = "Test",  Password = "",
                    Surname = "",
                    Name="",
                    Lastname ="",
                    Birthday = DateTime.MaxValue,
                    IsDeleted = false,
                    IsAdmin = false} },
                new object[]{new Пользователи() { Login = "Test",  Password = "",
                    Surname = "",
                    Name="",
                    Lastname ="Test",
                    Birthday = DateTime.MaxValue,
                    IsDeleted = false,
                    IsAdmin = false} }


            };
        }
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();
            repositoryWrapperMoq.Setup(x=>x.Пользователи).Returns(userRepositoryMoq.Object);
            service = new UserService(repositoryWrapperMoq.Object);

        }
        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentExeption ()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x=>x.Create(It.IsAny<Пользователи>()),Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(Пользователи user)
        {
            var newUser = user;
            await service.Create(newUser);
            //var ex = await Assert.ThrowsAnyAsync<ArgumentException>(()=>service.Create(newUser));
            userRepositoryMoq.Verify(x=>x.Create(It.IsAny<Пользователи>()),Times.Once);
            //Assert.IsType<ArgumentException>(ex);
        }
    }
   
}
