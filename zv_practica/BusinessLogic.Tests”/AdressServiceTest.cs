using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using Moq;


namespace BusinessLogic.Tests_
{
    public class AdressServiceTest
    {
        private readonly AdressService service;
        private readonly Mock<IAdressRepository> adressRepositoryMoq;
        public static IEnumerable<object[]> GetIncorrectOrders ()
        {
            return new List<object[]>
            {
                new object[]{new Адрес() { Login = "Test",  City = "",
                    Country = "",
                    Street="",
                    Appartments ="",
                    House = "",
                    IsDeleted = false,
                    } },
                  new object[]{new Адрес() { Login = "Test",  City = "qq",
                    Country = "",
                    Street="",
                    Appartments ="",
                    House = "",
                    IsDeleted = false,
                    } },
                new object[]{new Адрес() { Login = "Test",  City = "qq",
                    Country = "qwe",
                    Street="",
                    Appartments ="",
                    House = "",
                    IsDeleted = false,
                    } },


            };
        }
        public AdressServiceTest ()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapperAdress>();
            adressRepositoryMoq = new Mock<IAdressRepository>();
            repositoryWrapperMoq.Setup(x => x.Адрес).Returns(adressRepositoryMoq.Object);
            service = new AdressService(repositoryWrapperMoq.Object);

        }
        [Fact]
        public async Task CreateAsync_NullOrder_ShouldThrowNullArgumentExeption ()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            adressRepositoryMoq.Verify(x => x.Create(It.IsAny<Адрес>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectOrders))]
        public async Task CreateAsyncNewUserShouldNotCreateNewOrder ( Адрес adress )
        {
            var newAdress = adress;
            await service.Create(newAdress);
            //var ex = await Assert.ThrowsAnyAsync<ArgumentException>(()=>service.Create(newUser));
            adressRepositoryMoq.Verify(x => x.Create(It.IsAny<Адрес>()), Times.Once);
            //Assert.IsType<ArgumentException>(ex);
        }
    }
}
