using SqlSugar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeBlog.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity> FindByIdAsync(int id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);
        Task<List<TEntity>> QueryAsync();
        /// <summary>
        /// 自定义表达式条件查询
        /// </summary>
        /// <param name="func">表达式</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);
        /// <summary>
        /// 自定义带分页的表达式查询
        /// </summary>
        /// <param name="func">表达式</param>
        /// <param name="page">页码</param>
        /// <param name="size">条数</param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
    }

}
