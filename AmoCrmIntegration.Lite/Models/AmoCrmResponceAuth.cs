using Newtonsoft.Json;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of response for auth in CRM
    /// </summary>
    public class ResponseAuth
    {
        [JsonProperty("response")]
        public ResponseAuthValue Response { get; set; }
    }

    /// <summary>
    /// Type of response values for auth in CRM
    /// </summary>
    public class ResponseAuthValue
    {
        [JsonProperty("auth")]
        public bool Auth { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}
