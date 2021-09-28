using System.Text.Json;
using System.Text.Json.Serialization;

namespace kao_net_app.Model.Request.Auth
{
    public class SignInModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

    }
}
