using Newtonsoft.Json;

namespace Weather.Data.ResponseParams.ResponseNow
{
    public class MainPram
    {
        public decimal temp { get; set; }

        [JsonProperty("feels_like")] 
        public decimal feels { get; set; }

        public decimal pressure { get; set; }
        public uint humidity { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }

    }
}