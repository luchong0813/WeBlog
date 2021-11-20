using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using WeBlog.Api.Utility.ApiResponse;
using WeBlog.IService;

namespace WeBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _BlogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _BlogPostService = blogPostService;
        }

        [HttpGet("BlogPost")]
        public async Task<ActionResult<ApiResult>> GetBlogPost() {
            var blog= await _BlogPostService.QueryAsync();
            if (blog == null || blog.Count <= 0) return ApiResultHelper.Error("没有更多数据");
            return ApiResultHelper.Success(blog);
        }
    }
}
