namespace WeBlog.Api.Utility.ApiResponse
{
    public class ApiResult
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public dynamic Data { get; set; }
        public int Total { get; set; }
    }
}
