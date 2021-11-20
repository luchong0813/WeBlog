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
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        private readonly IAuthorRepository _AuthorRepository;

        public AuthorService(IAuthorRepository authorRepository) 
        {
            base._baseRepository = authorRepository;
            _AuthorRepository = authorRepository;
        }
    }
}
