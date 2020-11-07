﻿using TracerLib.Tracer;

namespace TracerLib.Serialization
{
    public interface ISerializer 
    {
        string Serialize(TraceResult traceResult);
    }
}