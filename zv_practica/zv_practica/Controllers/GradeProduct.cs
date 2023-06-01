using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zv_practica.Contracts;

namespace zv_practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeProduct : ControllerBase
    {
        private IGradeProductService _gradeProductService;
        public GradeProduct ( IGradeProductService gradeProductService )
        {
            _gradeProductService = gradeProductService;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            return Ok(await _gradeProductService.GetAll());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetBylogin ( string id )
        {
            return Ok(await _gradeProductService.GetByLogin(id));
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
                var userDto = request.Adapt<Оценкатовара>();
                await _gradeProductService.Create(userDto);
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
            var userDto = response.Adapt<Оценкатовара>();
            await _gradeProductService.Update(userDto);
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
        public async Task<IActionResult> Delete ( string id )
        {
            await _gradeProductService.Delete(id);
            return Ok();
        }
    }
}
