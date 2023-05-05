using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderProductService
    {
        Task<List<ЗаказТовара>> GetAll ();
        Task<ЗаказТовара> GetByLogin ( int login );
        Task Create ( ЗаказТовара model );
        Task Update ( ЗаказТовара model );
        Task Delete ( int login );
    }
}
