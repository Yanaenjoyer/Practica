using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderProductRepository : RepositoryBase<ЗаказТовара>, IOrderProductRepository
    {
        public OrderProductRepository ( MyDbContext repositoryContext )
            : base(repositoryContext) { }
    }
}
