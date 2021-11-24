using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBlog.Share.Utility.Attributes
{
    public class CustomResourceFilteAttribute : Attribute, IResourceFilter
    {
        private readonly IMemoryCache _Cache;

        public CustomResourceFilteAttribute(IMemoryCache cache)
        {
            _Cache = cache;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var path = context.HttpContext.Request.Path;
            var route = context.HttpContext.Request.QueryString.Value;
            var key = path + route;
            _Cache.Set(key, context.Result);
        }

       
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var path=context.HttpContext.Request.Path; //api/BlogPost
            var route = context.HttpContext.Request.QueryString.Value;  //?page=1&size=2
            var key = path + route;
            if (_Cache.TryGetValue(key, out object value)){
                context.Result = value as IActionResult;
            }
        }
    }
}
