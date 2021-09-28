using System.Text.Json.Serialization;

namespace kao_net_app.Model.Request.Auth
{
    public class SignupModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("passwordConfirm")]
        public string Password_Confirm { get; set; }

    }
}
