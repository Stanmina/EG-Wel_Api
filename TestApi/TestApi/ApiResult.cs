namespace TestApi
{
    public class ApiResult
    {
        public bool IsError { get; set; }
        public int? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
