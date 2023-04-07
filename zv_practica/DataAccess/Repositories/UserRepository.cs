using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Domain;
using Domain.Models;


namespace DataAccess.Repositories
{
    
    public class UserRepository:RepositoryBase<Пользователи>,IUserRepository
    {
        public UserRepository (MyDbContext repositoryContext)
            :base (repositoryContext) { }
    }
    
}
