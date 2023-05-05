using DataAccess.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapperOrderProduct : IRepositoryWrapperOrderProduct
    {
        private MyDbContext _repoContext;

        private IOrderProductRepository _orderproduct;

        public IOrderProductRepository ЗаказТовара
        {
            get
            {
                if (_orderproduct == null)
                {
                    _orderproduct = (IOrderProductRepository?)new OrderProductRepository(_repoContext);
                }
                return _orderproduct;
            }
        }
        public RepositoryWrapperOrderProduct ( MyDbContext repositoryContext )
        {
            _repoContext = repositoryContext;
        }
        public async Task Save ()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
