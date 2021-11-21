using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using WeBlog.Api.Utility.ApiResponse;
using WeBlog.IService;
using WeBlog.Model;

namespace WeBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogTypeController : ControllerBase
    {
        private readonly ITypeInfoService _TypeInfoService;

        public BlogTypeController(ITypeInfoService typeInfoService)
        {
            _TypeInfoService = typeInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResult>> Get()
        {
            var typeInfo = await _TypeInfoService.QueryAsync();
            if (typeInfo == null || typeInfo.Count <= 0) return ApiResultHelper.Error("没有更多数据");
            return ApiResultHelper.Success(typeInfo);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult>> Creat(string typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName)) return ApiResultHelper.Error("标签名称不允许为空");

            var result = await _TypeInfoService.CreateAsync(new TypeInfo() { TagName = typeName });
            if (result) return ApiResultHelper.Success(typeName);
            return ApiResultHelper.Error("文章标签创建失败");
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            var typeInfo = await _TypeInfoService.FindByIdAsync(id);
            if (typeInfo == null) return ApiResultHelper.Error("没有找到该文章标签");
            var result = await _TypeInfoService.DeleteAsync(id);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error("文章标签删除失败");
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult>> Edit(int id, string typeName)
        {
            var typeInfo = await _TypeInfoService.FindByIdAsync(id);
            if (typeInfo == null) return ApiResultHelper.Error("没有找到该文章标签");
            typeInfo.TagName = typeName;
            var result = await _TypeInfoService.UpdateAsync(typeInfo);
            if (result) return ApiResultHelper.Success(result);
            return ApiResultHelper.Error("文章标签编辑失败");
        }
    }
}
