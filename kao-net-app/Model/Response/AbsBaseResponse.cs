using System.Text.Json.Serialization;

namespace kao_net_app.Model.Response
{
    abstract public class AbsBaseResponse
    {
        public enum ResponseStatus
        {
            SUCCESS,VALID
        }

        [JsonPropertyName("status")]
        public int Status { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="status"></param>
        public AbsBaseResponse(ResponseStatus status)
        {
            this.Status = (int)status;
        }
    }
}
