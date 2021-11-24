using SqlSugar;

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
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public async override Task<List<BlogPost>> QueryAsync()
        {
            return await base.Context.Queryable<BlogPost>()
                .Mapper(b => b.AuthorInfo, b => b.AuthorId, b => b.AuthorInfo.Id)
                .Mapper(b => b.TypeInfo, b => b.TypeId, b => b.TypeInfo.Id)
                .ToListAsync();
        }

        public async override Task<List<BlogPost>> QueryAsync(Expression<Func<BlogPost, bool>> func)
        {
            return await base.Context.Queryable<BlogPost>()
                .Where(func)
                .Mapper(b => b.AuthorInfo, b => b.AuthorId,b=>b.AuthorInfo.Id)
                .Mapper(b => b.TypeInfo, b => b.TypeId ,b=> b.TypeInfo.Id)
                .ToListAsync();
        }

        public override Task<List<BlogPost>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<BlogPost>()
                .Mapper(b => b.AuthorInfo, b => b.AuthorId, b => b.AuthorInfo.Id)
                .Mapper(b => b.TypeInfo, b => b.TypeId, b => b.TypeInfo.Id)
                .ToPageListAsync(page, size, total);
        }

        public override Task<List<BlogPost>> QueryAsync(Expression<Func<BlogPost, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<BlogPost>()
                .Where(func)
                .Mapper(b => b.AuthorInfo, b => b.AuthorId, b => b.AuthorInfo.Id)
                .Mapper(b => b.TypeInfo, b => b.TypeId, b => b.TypeInfo.Id)
                .ToPageListAsync(page, size, total);
        }
    }
}
