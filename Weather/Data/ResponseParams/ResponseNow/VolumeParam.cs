using Newtonsoft.Json;

namespace Weather.Data.ResponseParams.ResponseNow
{
    public class VolumeParam
    {
        [JsonProperty("1h")]
        public decimal h1 { get; set; }

        [JsonProperty("3h")]
        public decimal h3 { get; set; }
    }
}