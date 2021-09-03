using Newtonsoft.Json;

namespace kao_net_app.Model.Response
{
    public class ValidResponse : AbsBaseResponse
    {
        [JsonProperty("message")]
        public string Message { get; }

        public ValidResponse(string message) : base(ResponseStatus.VALID)
        {
            this.Message = message;
        }
    }
}
