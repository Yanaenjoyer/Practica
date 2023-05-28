using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<Пользователи>>GetAll();
        Task<Пользователи>GetById   (string id);
        Task Create(Пользователи model);
        Task Update(Пользователи model);
        Task Delete(string id);
        Task<Пользователи> Login (string email, string password );
        
    }
}
