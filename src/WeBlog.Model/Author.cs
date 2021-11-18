using SqlSugar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBlog.Model
{
    public class Author : BaseId
    {
        /// <summary>
        /// 作者姓名
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(12)")]
        public string Name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(18)")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string UserPwd { get; set; }
    }

}
