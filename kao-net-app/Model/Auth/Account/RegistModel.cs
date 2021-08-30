using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kao_net_app.Model.Auth.Account
{
    public class RegistModel
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "passwordConfirm")]
        public string Password_Confirm { get; set; }

    }
}
