namespace BackEnd.TestGetechnologies.Service.Common.Response
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Success {  get; set; }
    }
}
