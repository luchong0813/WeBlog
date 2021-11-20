using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

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
        public async Task<ActionResult> GetBlogPost() {
            var blog= await _BlogPostService.QueryAsync();
            return Ok(blog);
        }
    }
}
