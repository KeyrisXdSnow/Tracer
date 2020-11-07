﻿using System.Collections.Generic;
using Newtonsoft.Json;
using TracerLib.Tracer;

namespace TracerLib.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var arrays = new Dictionary<string, ICollection<ThreadTrace>>
            {
                {"threads", traceResult.GetThreadTraces().Values}
            };
            
            return JsonConvert.SerializeObject(arrays, Formatting.Indented);
        }
    }
}