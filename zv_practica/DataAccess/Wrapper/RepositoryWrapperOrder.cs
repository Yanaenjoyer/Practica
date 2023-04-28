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
    public class RepositoryWrapperOrder:IRepositoryWrapperOrder
    {
        private MyDbContext _repoContext;

        private IOrderRepository _order;

        public IOrderRepository Заказ
        {
            get
            {
                if (_order == null)
                {
                    _order = (IOrderRepository?) new OrderRepository(_repoContext);
                }
                return _order;
            }
        }
        public RepositoryWrapperOrder(MyDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
