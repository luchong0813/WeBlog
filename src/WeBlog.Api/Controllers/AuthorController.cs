﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using WeBlog.Api.Utility.ApiResponse;
using WeBlog.Api.Utility.MD5Util;
using WeBlog.IService;
using WeBlog.Model;

namespace WeBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                UserName = userName,
                UserPwd = MD5Helper.GenerateMD5(userPwd)
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

        [HttpGet]
        public async Task<ActionResult<ApiResult>> Get()
        {
            var authors = await _AuthorService.QueryAsync();
            if (authors == null || authors.Count <= 0) return ApiResultHelper.Error("没有更多数据");
            return ApiResultHelper.Success(authors);
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult>> Edit(string name)
        {
            var id = Convert.ToInt32(User.FindFirst("Id").Value);
            var author = await _AuthorService.FindByIdAsync(id);
            author.Name = name;
            var result = await _AuthorService.UpdateAsync(author);
            if (result) return ApiResultHelper.Success(null);
            return ApiResultHelper.Error("修改失败");
        }
    }
}
