using Newtonsoft.Json;

namespace kao_net_app.Model.Request.Auth
{
    public class SignupModel
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "passwordConfirm")]
        public string Password_Confirm { get; set; }

    }
}
