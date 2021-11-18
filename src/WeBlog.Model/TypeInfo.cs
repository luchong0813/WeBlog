using SqlSugar;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBlog.Model
{
    public class TypeInfo : BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(8)")]
        public string TagName { get; set; }
    }

}
