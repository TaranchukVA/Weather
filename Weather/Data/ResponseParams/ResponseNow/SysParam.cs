using Newtonsoft.Json;
using System;

namespace Weather.Data.ResponseParams.ResponseNow
{
    public class SysParam
    {

        private DateTime? sunRise;
        private DateTime? sunSet;
        private readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);


        [JsonProperty("sunrise")]
        public long? unixSunRise
        {
            set
            {
                if (value != null)
                    sunRise = epoch.AddSeconds((double)value);
            }
        }
        public DateTime? SunRise { get { return sunRise; } set { sunRise = value; } }

        [JsonProperty("sunset")]
        public long? unixSunSet
        {
            set
            {
                if (value != null)
                    sunSet = epoch.AddSeconds((double)value);
            }
        }
        public DateTime? SunSet { get { return sunSet; } set { sunSet = value; } }

        public string country { get; set; }

    }
}