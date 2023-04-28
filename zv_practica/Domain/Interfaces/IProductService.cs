using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<Товар>> GetAll();
        Task<Товар> GetByLogin(int login);
        Task Create(Товар model);
        Task Update(Товар model);
        Task Delete(int login);
    }
}
