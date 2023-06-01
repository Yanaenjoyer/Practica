using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class GradeProductService:IGradeProductService
    {
        private IRepositoryWrapperGradeProduct _repositoryWrapper;
        public GradeProductService ( IRepositoryWrapperGradeProduct repositoryWrapper )
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Оценкатовара>> GetAll ()
        {
            return await _repositoryWrapper.Оценкатовара.FindAll();
        }

        public async Task<Оценкатовара> GetByLogin ( string login )
        {
            var user = await _repositoryWrapper.Оценкатовара
            .FindByCondition(x => x.Login == login);
            return user.First();
        }
        public async Task Create ( Оценкатовара model )
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            await _repositoryWrapper.Оценкатовара.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update ( Оценкатовара model )
        {
            _repositoryWrapper.Оценкатовара.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete ( string login )
        {
            var user = await _repositoryWrapper.Оценкатовара
            .FindByCondition(x => x.Login == login);
            _repositoryWrapper.Оценкатовара.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
