using Newtonsoft.Json;

namespace kao_net_app.Model.Response
{
    [JsonObject]
    public class SuccessResponse<T> : AbsBaseResponse
    {
        [JsonProperty("data")]
        public T Data { get; }

        public SuccessResponse(T data):base(ResponseStatus.SUCCESS)
        {
            this.Data = data;
        }
    }
}
