using SqlSugar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using WeBlog.IRepository;
using WeBlog.IService;

namespace WeBlog.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public async Task<bool> CreateAsync(TEntity entity)
        {
           return await _baseRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           return await _baseRepository.DeleteAsync(id);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _baseRepository.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await _baseRepository.QueryAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
           return await _baseRepository.QueryAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await _baseRepository.QueryAsync(page, size, total);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await _baseRepository.QueryAsync(func, page, size, total);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
