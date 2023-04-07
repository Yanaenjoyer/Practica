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
        public class UserController : ControllerBase
        {
            private IUserService _userService;
            public UserController(IUserService userService)
            {
                _userService = userService;
            }



            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _userService.GetAll());
            }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _userService.GetById(id));
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
      public async Task<IActionResult> Add( CreateUserRequest request)
        {
           
            {
               var userDto = request.Adapt<Пользователи>();
                await _userService.Create(userDto);
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
        public async Task<IActionResult> Update(GetUSerResponse response)
        {
            var userDto = response.Adapt<Пользователи>();
            await _userService.Update(userDto);
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
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
    
}
