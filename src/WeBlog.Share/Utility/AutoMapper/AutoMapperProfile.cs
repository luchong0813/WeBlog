using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeBlog.Model;
using WeBlog.Model.Dto;

namespace WeBlog.Share.Utility.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
