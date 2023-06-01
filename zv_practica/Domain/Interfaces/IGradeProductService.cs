using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public  interface IGradeProductService
    {
        Task<List<Оценкатовара>> GetAll ();
        Task<Оценкатовара> GetByLogin ( string login );
        Task Create ( Оценкатовара model );
        Task Update ( Оценкатовара model );
        Task Delete ( string login );
    }
}
