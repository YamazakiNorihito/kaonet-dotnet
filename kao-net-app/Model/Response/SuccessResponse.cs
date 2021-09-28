using System.Text.Json.Serialization;

namespace kao_net_app.Model.Response
{
    public class SuccessResponse<T> : AbsBaseResponse
    {
        [JsonPropertyName("data")]
        public T Data { get; }

        public SuccessResponse(T data):base(ResponseStatus.SUCCESS)
        {
            this.Data = data;
        }
    }
}
