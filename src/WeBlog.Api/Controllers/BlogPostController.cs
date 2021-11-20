﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using WeBlog.Api.Utility.ApiResponse;
using WeBlog.IService;
using WeBlog.Model;

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

        [HttpGet]
        public async Task<ActionResult<ApiResult>> Get() {
            var blog= await _BlogPostService.QueryAsync();
            if (blog == null || blog.Count <= 0) return ApiResultHelper.Error("没有更多数据");
            return ApiResultHelper.Success(blog);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResult>> Creat(string title,string content,int typeId) {
            if (string.IsNullOrWhiteSpace(title)) return ApiResultHelper.Error("标题不能为空");
            if (string.IsNullOrWhiteSpace(content)) return ApiResultHelper.Error("文章内容不能为空");
            BlogPost blog = new BlogPost()
            {
                Title=title,
                Content=content,
                TypeId=typeId,
                LikeCount=0,
                BrowseCount=0,
                CreatTime=DateTime.Now,
                AuthorId=1
            };
            var result=await _BlogPostService.CreateAsync(blog);
            if(result) return ApiResultHelper.Success(blog);
            return ApiResultHelper.Error("文章创建失败");
         }

        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            var blog = await _BlogPostService.FindByIdAsync(id);
            if (blog == null) return ApiResultHelper.Error("要删除的文章不存在");
            var result = await _BlogPostService.DeleteAsync(blog.Id);
            if (result) return ApiResultHelper.Success(blog);
            return ApiResultHelper.Error("删除失败");
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult>> Edit(int id, string title, string content, int typeId)
        {
            var blog = await _BlogPostService.FindByIdAsync(id);
            if (blog == null) return ApiResultHelper.Error("要编辑的文章不存在");
            blog.Title = title;
            blog.Content = content;
            blog.TypeId = typeId;
            var result = await _BlogPostService.UpdateAsync(blog);
            if (result) return ApiResultHelper.Success(blog);
            return ApiResultHelper.Error("文章编辑失败");
        }
    }
}
