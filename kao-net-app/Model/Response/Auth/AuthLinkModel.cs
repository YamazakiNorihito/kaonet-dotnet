using System.Text.Json.Serialization;

namespace kao_net_app.Model.Response.Auth
{
    public class AuthLinkModel
    {
        [JsonPropertyName("idToken")]
        public string Token { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonPropertyName("expiresIn")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("localId")]
        public string LocalId { get; set; }
    }
}
