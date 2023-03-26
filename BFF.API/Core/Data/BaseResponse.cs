namespace BFF.Core.Data
{
    public class BaseResponse<T> where T : new()
    {
        public BaseResponse()
        {
            Data = new T();
        }
        public T Data { get; set; }
    }
}
