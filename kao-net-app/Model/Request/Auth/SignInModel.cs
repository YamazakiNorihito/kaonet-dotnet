using Newtonsoft.Json;

namespace kao_net_app.Model.Request.Auth
{
    public class SignInModel
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

    }
}
