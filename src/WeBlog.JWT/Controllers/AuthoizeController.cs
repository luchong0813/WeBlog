using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;

using WeBlog.Api.Utility.ApiResponse;
using WeBlog.Api.Utility.MD5Util;
using WeBlog.IService;

namespace WeBlog.JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoizeController : ControllerBase
    {
        private readonly IAuthorService _AuthorService;

        public AuthoizeController(IAuthorService authorService)
        {
            _AuthorService = authorService;
        }

        [HttpPost]
        public async Task<ApiResult> Login(string userName, string userPwd)
        {
            var author = await _AuthorService
                .FindAsync(a =>
                a.UserName.Equals(userName) &&
                a.UserPwd.Equals(MD5Helper.GenerateMD5(userPwd)));
            if (author != null)
            {
                //登录成功
                var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, author.Name),
                new Claim("Id",author.Id.ToString()),
                new Claim("UserName",author.UserName)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF"));
                //issuer代表颁发Token的Web应用程序，audience是Token的受理者
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:6060",
                    audience: "http://localhost:5000",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelper.Success(jwtToken);
            }
            else
            {
                return ApiResultHelper.Error("账号或密码错误");
            }
            return ApiResultHelper.Error("登陆失败，内部服务器错误");
        }
    }
}
