using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain;
using BusinessLogic.Services;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private MyDbContext _repoContext;

        private IUserRepository _user;

        public IUserRepository Пользователи
        {
            get
            {
                if(_user == null)
                {
                    _user = (IUserRepository?)new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(MyDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync(); 
        }

    }
}
