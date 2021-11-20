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
    public class TypeInfoService : BaseService<TypeInfo>, ITypeInfoService
    {
        private readonly ITypeInfoRepository _TypeInfoRepository;

        public TypeInfoService(ITypeInfoRepository typeInfoRepository)
        {
            base._baseRepository = typeInfoRepository;
            _TypeInfoRepository = typeInfoRepository;
        }
    }
}
