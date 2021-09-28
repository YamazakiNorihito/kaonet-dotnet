
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace kao_net_app.Model.Response
{
    public class ValidResponse : AbsBaseResponse
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions()
        {
            // すべての言語セットをエスケープせずにシリアル化させる
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        [JsonPropertyName("message")]
        public string Message { get; }

        public ValidResponse(string message) : base(ResponseStatus.VALID)
        {
            this.Message = message;
        }


        public ValidResponse(Exception ex) : this(System.Text.Json.JsonSerializer.Serialize(ex, options))
        {

        }
    }
}
