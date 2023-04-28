using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain;

using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
   public class ProductService: IProductService
    {
        private IRepositoryWrapperProduct _repositoryWrapper;
        public ProductService(IRepositoryWrapperProduct repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Товар>> GetAll()
        {
            return await _repositoryWrapper.Товар.FindAll();
        }

        public async Task Create(Товар model)
        {
            await _repositoryWrapper.Товар.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Товар model)
        {
            _repositoryWrapper.Товар.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.Товар
            .FindByCondition(x => x.ProductId == id);
            _repositoryWrapper.Товар.Delete(user.First());
            _repositoryWrapper.Save();
        }

        public async Task<Товар> GetByLogin ( int login )
        {
            var user = await _repositoryWrapper.Товар
          .FindByCondition(x => x.ProductId == login);
            return user.First();
        }
    }
}
