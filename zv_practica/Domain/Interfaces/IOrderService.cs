using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderService
    {
        Task<List<Заказ>> GetAll();
        Task<Заказ> GetByLogin(string login);
        Task Create(Заказ model);
        Task Update(Заказ model);
        Task Delete(string login);
    }
}
