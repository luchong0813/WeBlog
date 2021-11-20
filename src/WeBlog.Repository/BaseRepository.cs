using SqlSugar;
using SqlSugar.IOC;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using WeBlog.IRepository;
using WeBlog.Model;

namespace WeBlog.Repository
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {

        public BaseRepository(ISqlSugarClient context = null) : base(context)
        {
            base.Context =DbScoped.Sugar;
            ////如果不存在创建数据库
            //base.Context.DbMaintenance.CreateDatabase(); //个别数据库不支持
            ////创建表
            //base.Context.CodeFirst.InitTables(
            //    typeof(Author),
            //    typeof(TypeInfo),
            //    typeof(BlogPost));
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public virtual async Task<List<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public virtual async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await base.Context
                .Queryable<TEntity>()
                .ToPageListAsync(page, size, total);
        }

        public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await base.Context
                .Queryable<TEntity>()
                .Where(func)
                .ToPageListAsync(page, size, total);
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }
    }

}
