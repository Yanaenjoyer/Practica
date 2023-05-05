using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {



        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Пользователи>> GetAll()
        {
            return await _repositoryWrapper.Пользователи.FindAll();
        }
        
public async Task<Пользователи> GetById(string id)
        {
            var user = await _repositoryWrapper.Пользователи
            .FindByCondition(x => x.Login == id);
            return user.First();
        }
        public async Task Create(Пользователи model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Пользователи.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Пользователи model)
        {
            _repositoryWrapper.Пользователи.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(string id)
        {
            var user = await _repositoryWrapper.Пользователи
            .FindByCondition(x => x.Login == id);
            _repositoryWrapper.Пользователи.Delete(user.First());
            _repositoryWrapper.Save();
        }


    }
}
