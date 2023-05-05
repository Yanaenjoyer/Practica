using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class AdressService : IAdressService
    {


        private IRepositoryWrapperAdress _repositoryWrapper;
        public AdressService ( IRepositoryWrapperAdress repositoryWrapper )
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Адрес>> GetAll ()
        {
            return await _repositoryWrapper.Адрес.FindAll();
        }

        public async Task<Адрес> GetByLogin ( string login )
        {
            var user = await _repositoryWrapper.Адрес
            .FindByCondition(x => x.Login == login);
            return user.First();
        }
        public async Task Create ( Адрес model )
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Адрес.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update ( Адрес model )
        {
            _repositoryWrapper.Адрес.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete ( string login )
        {
            var user = await _repositoryWrapper.Адрес
            .FindByCondition(x => x.Login == login);
            _repositoryWrapper.Адрес.Delete(user.First());
            _repositoryWrapper.Save();
        }


    }
}
