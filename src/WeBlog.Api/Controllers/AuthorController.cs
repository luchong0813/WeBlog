using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using WeBlog.Api.Utility.ApiResponse;
using WeBlog.Api.Utility.MD5Util;
using WeBlog.IService;
using WeBlog.Model;

namespace WeBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthorController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult>> Creat(string name, string userName, string userPwd)
        {
            //校验数据库是否已经存在该用户
            var oldAuthor = await _AuthorService.FindAsync(u => u.UserName.Equals(userName));
            if (oldAuthor != null) return ApiResultHelper.Error("该用户已存在，无法重复创建");
            Author authorModel = new Author()
            {
                Name = name,
                UserName = MD5Helper.GenerateMD5(userName),
                UserPwd = userPwd
            };
            var result = await _AuthorService.CreateAsync(authorModel);
            if (result) return ApiResultHelper.Success(authorModel);
            return ApiResultHelper.Error("用户创建失败");
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            var author = await _AuthorService.FindByIdAsync(id);
            if (author == null) return ApiResultHelper.Error("该用户不存在");
            var result = await _AuthorService.DeleteAsync(author.Id);
            if (result) return ApiResultHelper.Success(author);
            return ApiResultHelper.Error("用户删除失败");
        }
    }
}
