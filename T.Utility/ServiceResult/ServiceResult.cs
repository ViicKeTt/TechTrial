using Newtonsoft.Json;

namespace T.Utility.ServiceResult
{
    public class ServiceResult<T> where T : class
    {
        [JsonProperty("status_code")]
        public int Status_code { get; set; }
        [JsonProperty("isError")]
        public bool IsError { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
