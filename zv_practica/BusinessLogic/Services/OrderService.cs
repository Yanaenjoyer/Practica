using Domain.Interfaces;
using Domain.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {


        private IRepositoryWrapperOrder _repositoryWrapper;
        public OrderService(IRepositoryWrapperOrder repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Заказ>> GetAll()
        {
            return await _repositoryWrapper.Заказ.FindAll();
        }

        public async Task<Заказ> GetByLogin(string login)
        {
            var user = await _repositoryWrapper.Заказ
            .FindByCondition(x => x.Login == login);
            return user.First();
        }
        public async Task Create(Заказ model)
        {
            await _repositoryWrapper.Заказ.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Заказ model)
        {
            _repositoryWrapper.Заказ.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(string login)
        {
            var user = await _repositoryWrapper.Заказ
            .FindByCondition(x => x.Login == login);
            _repositoryWrapper.Заказ.Delete(user.First());
            _repositoryWrapper.Save();
        }


    }
}
