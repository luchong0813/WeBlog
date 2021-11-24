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
            CreateMap<BlogPost, BlogPostDto>()
                .ForMember(dest => dest.AuthorName,
                source => source
                .MapFrom(src => src.AuthorInfo.Name))
                .ForMember(dest => dest.TypeName,
                source => source
                .MapFrom(src => src.TypeInfo.TagName));
        }
    }
}
