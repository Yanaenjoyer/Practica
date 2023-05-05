using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zv_practica.Contracts;
using Mapster;

namespace zv_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController ( IProductService productService )
        {
            _productService = productService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            return Ok(await _productService.GetAll());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById ( int id )
        {
            return Ok(await _productService.GetByLogin(id));
        }

        /// <summary>
        /// Создание нового пользователя
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
        [HttpPost]
        public async Task<IActionResult> Add ( CreateUserRequest request )
        {

            {
                var userDto = request.Adapt<Товар>();
                await _productService.Create(userDto);
                return Ok();

            }

        }
        /// <summary>
        /// Изменение нового пользователя
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
        [HttpPut]
        public async Task<IActionResult> Update ( GetUSerResponse response )
        {
            var userDto = response.Adapt<Товар>();
            await _productService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя
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
        public async Task<IActionResult> Delete ( int id )
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
