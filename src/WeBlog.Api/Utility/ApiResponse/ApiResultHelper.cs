using SqlSugar;

namespace WeBlog.Api.Utility.ApiResponse
{
    public static class ApiResultHelper
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static ApiResult Success(dynamic data)
        {
            return new ApiResult()
            {
                Code = 200,
                Msg = "操作成功",
                Data = data
            };
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="total">总页数</param>
        /// <returns></returns>
        public static ApiResult Success(dynamic data, RefAsync<int> total)
        {
            return new ApiResult()
            {
                Code = 200,
                Msg = "操作成功",
                Data = data,
                Total = total
            };
        }

        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="msg">失败描述</param>
        /// <returns></returns>
        public static ApiResult Error(string msg)
        {
            return new ApiResult()
            {
                Code=500,
                Msg = msg
            };
        }
    }
}
