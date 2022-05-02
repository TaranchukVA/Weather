using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Weather.Data.ResponseParams.ResponseNow
{
    public class MasterParam
    {
        private readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);


        private DateTime? dayTime;

        [JsonProperty("dt")]
        public long? unixSunRise
        {
            set
            {
                if (value != null)
                    dateTime = epoch.AddSeconds((double)value);
            }
        }

        public List<WeatherParam> weather { get; set; }
        public MainPram main { get; set; }
        public uint visibility { get; set; }
        public WindParam wind { get; set; }
        public CloudsParam clouds { get; set; }
        public VolumeParam rain { get; set; }
        public VolumeParam snow { get; set; }
        public DateTime? dateTime { get { return dayTime; } set { dayTime = value; } }
    }
}