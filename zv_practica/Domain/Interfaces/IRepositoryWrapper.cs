using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain
{
    public interface IRepositoryWrapper
    {
        IUserRepository Пользователи { get; }
        Task Save();

    }
}
