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
    public class RepositoryWrapperGradeProduct:IRepositoryWrapperGradeProduct
    {
        private MyDbContext _repoContext;

        private IGradeProductRepository _product;

        public IGradeProductRepository Оценкатовара
        {
            get
            {
                if (_product == null)
                {
                    _product = (IGradeProductRepository?)new GradeProductRepository(_repoContext);
                }
                return _product;
            }
        }
        public RepositoryWrapperGradeProduct( MyDbContext repositoryContext )
        {
            _repoContext = repositoryContext;
        }
        public async Task Save ()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}

