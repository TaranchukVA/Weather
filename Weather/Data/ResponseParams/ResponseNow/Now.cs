using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Weather.Data.ResponseParams.ResponseNow
{
    public class Now : MasterParam
    {
        
        public SysParam sys { get; set; }
        public string name { get; set; }
    }
}
