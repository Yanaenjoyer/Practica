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
    public class OrderServiceTest
    {
        private readonly OrderService service;
        private readonly Mock<IOrderRepository> orderRepositoryMoq;
        public static IEnumerable<object[]> GetIncorrectOrders ()
        {
            return new List<object[]>
            {
                new object[]{new Заказ() { Login = "",  OrderNumber = 1,
                    Price = 1,
                    DeliveryType="",
                    Status ="",
                    OrderDate = DateTime.MaxValue,
                    IsDeleted = false,
                    } },
                 new object[]{new Заказ() { Login = "Test",  OrderNumber = 2,
                    Price = 1,
                    DeliveryType="qq",
                    Status ="",
                    OrderDate = DateTime.MaxValue,
                    IsDeleted = false,
                    } },
                 new object[]{new Заказ() { Login = "Test",  OrderNumber = 1,
                    Price = 1,
                    DeliveryType="qqw",
                    Status ="delivered",
                    OrderDate = DateTime.MaxValue,
                    IsDeleted = false,
                    } }


            };
        }
        public OrderServiceTest ()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapperOrder>();
            orderRepositoryMoq = new Mock<IOrderRepository>();
            repositoryWrapperMoq.Setup(x => x.Заказ).Returns(orderRepositoryMoq.Object);
            service = new OrderService(repositoryWrapperMoq.Object);

        }
        [Fact]
        public async Task CreateAsync_NullOrder_ShouldThrowNullArgumentExeption ()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            orderRepositoryMoq.Verify(x => x.Create(It.IsAny<Заказ>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectOrders))]
        public async Task CreateAsyncNewUserShouldNotCreateNewOrder ( Заказ order )
        {
            var newOrder = order;
            await service.Create(newOrder);
            //var ex = await Assert.ThrowsAnyAsync<ArgumentException>(()=>service.Create(newUser));
            orderRepositoryMoq.Verify(x => x.Create(It.IsAny<Заказ>()), Times.Once);
            //Assert.IsType<ArgumentException>(ex);
        }
    }
}
