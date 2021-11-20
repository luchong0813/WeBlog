using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeBlog.IRepository;
using WeBlog.Model;

namespace WeBlog.Repository
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
    }
}
