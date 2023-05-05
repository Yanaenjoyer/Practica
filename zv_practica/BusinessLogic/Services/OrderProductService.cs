using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OrderProductService : IOrderProductService
    {


        private IRepositoryWrapperOrderProduct _repositoryWrapper;
        public OrderProductService ( IRepositoryWrapperOrderProduct repositoryWrapper )
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<ЗаказТовара>> GetAll ()
        {
            return await _repositoryWrapper.ЗаказТовара.FindAll();
        }

        public async Task<ЗаказТовара> GetByLogin ( int login )
        {
            var user = await _repositoryWrapper.ЗаказТовара
            .FindByCondition(x => x.ProductId == login);
            return user.First();
        }
        public async Task Create ( ЗаказТовара model )
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.ЗаказТовара.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update ( ЗаказТовара model )
        {
            _repositoryWrapper.ЗаказТовара.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete ( int login )
        {
            var user = await _repositoryWrapper.ЗаказТовара
            .FindByCondition(x => x.ProductId == login);
            _repositoryWrapper.ЗаказТовара.Delete(user.First());
            _repositoryWrapper.Save();
        }


    }
}
