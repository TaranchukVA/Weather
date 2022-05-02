using System.Collections.Generic;
using Weather.Data.ResponseParams.ResponseNow;

namespace Weather.Data.ResponseParams.ResponseFiveDays
{
    public class FiveDays
    {
        public List<MasterParam> list { get; set; }
        public CityParam city { get; set; }
    }
}
