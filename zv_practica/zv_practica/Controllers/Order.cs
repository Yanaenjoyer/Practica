using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using DataAccess.Models;
using Domain.Models;
using zv_practica.Contracts;
using Microsoft.AspNetCore.Identity;
using Mapster;
using Azure.Core;

namespace zv_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _orderService.GetByLogin(id));
        }

        /// <summary>
        /// Создание нового закааз
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "OrderNumber" : "1",
        /// "OrderDate" : "01-01-2000",
        /// "Login" : "123",
        /// "Price" : "1000",
        /// "IsDeleted" : "True"
        /// "deliveryType":"courier"
        /// "Status":"delivered"
        /// 
        /// }
        ///
        /// </remarks>
        /// <param name="model">Заказ</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderRequest request)
        {

            {
                var userDto = request.Adapt<Заказ>();
                await _orderService.Create(userDto);
                return Ok();

            }

        }
        /// <summary>
        /// Изменение заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "OrderNumber" : "1",
        /// "OrderDate" : "01-01-2000",
        /// "Login" : "123",
        /// "Price" : "1000",
        /// "IsDeleted" : "True"
        /// "deliveryType":"courier"
        /// "Status":"delivered"
        /// 
        /// }
        ///
        /// </remarks>
        /// <param name="model">Заказ</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(GetOrderResponse response)
        {
            var userDto = response.Adapt<Заказ>();
            await _orderService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление  Заказа
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "Login" : "A4Tech Bloody B188",
        /// "password" : "!Pa$$word123@",
        /// "Surname" : "Иванов",
        /// "Name" : "Иван",
        /// "Lastname" : "Иванович"
        /// "Birthday":"2000-01-01"
        /// "IsDeleted":"True"
        /// "IsAdmin":"False"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _orderService.Delete(id);
            return Ok();
        }
    }

}
