using Org.BouncyCastle.Crypto;
using SqlSugar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeBlog.Model
{
    public class BlogPost : BaseId
    {
        /// <summary>
        /// 文章标题
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(10)")]
        public string? Title { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        [SugarColumn(ColumnDataType = "text")]
        public string? Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int BrowseCount { get; set; }
        /// <summary>
        /// 点赞量
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// 文章类型Id
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// 作者Id
        /// </summary>
        public int AuthorId { get; set; }

/// <summary>
/// 作者（不映射到数据库）
/// </summary>
        [SugarColumn(IsIgnore = true)]
        public Author? AuthorInfo { get; set; }
        [SugarColumn(IsIgnore = true)]
        public TypeInfo? TypeInfo { get; set; }
    }

}
