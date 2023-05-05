using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
  
    public interface IAdressService
    {
        Task<List<Адрес>> GetAll ();
        Task<Адрес> GetByLogin ( string login );
        Task Create ( Адрес model );
        Task Update ( Адрес model );
        Task Delete ( string login );
    }
}
