﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeBlog.IService;
using WeBlog.Model;

namespace WeBlog.Service
{
    public class AuthorRepository : BaseService<Author>, IAuthorService
    {
    }
}