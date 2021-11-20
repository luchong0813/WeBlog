using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeBlog.IRepository;
using WeBlog.IService;
using WeBlog.Model;

namespace WeBlog.Service
{
    public class BlogPostService : BaseService<BlogPost>, IBlogPostService
    {
        private readonly IBlogPostRepository _BlogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            base._baseRepository = blogPostRepository;
            _BlogPostRepository = blogPostRepository;
        }
    }
}
