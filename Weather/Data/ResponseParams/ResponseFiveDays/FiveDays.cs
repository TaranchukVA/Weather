using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Data.ResponseParams.ResponseNow;

namespace Weather.Data.ResponseParams.ResponseFiveDays
{
    public class FiveDays
    {
        public List<MasterParam> list { get; set; }
        public CityParam city { get; set; }
    }
}
