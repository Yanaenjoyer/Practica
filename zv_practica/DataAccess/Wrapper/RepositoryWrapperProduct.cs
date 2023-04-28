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
    public class RepositoryWrapperProduct : IRepositoryWrapperProduct
    {
        private MyDbContext _repoContext;

        private IProductRepository _product;

        public IProductRepository Товар
        {
            get
            {
                if (_product == null)
                {
                    _product = (IProductRepository?)new ProductRepository(_repoContext);
                }
                return _product;
            }
        }
        public RepositoryWrapperProduct(MyDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
