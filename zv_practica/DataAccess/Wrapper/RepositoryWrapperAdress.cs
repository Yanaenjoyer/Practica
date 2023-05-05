using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapperAdress : IRepositoryWrapperAdress
    {
        private MyDbContext _repoContext;

        private IAdressRepository _adress;

        public IAdressRepository Адрес
        {
            get
            {
                if (_adress == null)
                {
                    _adress = (IAdressRepository?)new UserRepository(_repoContext);
                }
                return _adress;
            }
        }
        public RepositoryWrapperAdress ( MyDbContext repositoryContext )
        {
            _repoContext = repositoryContext;
        }
        public async Task Save ()
        {
            await _repoContext.SaveChangesAsync();
        }

    }
}
