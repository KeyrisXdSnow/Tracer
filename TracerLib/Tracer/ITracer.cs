﻿﻿ namespace TracerLib.Tracer
{
    public interface ITracer
    {
        void StartTrace();
        
        void StopTrace();
    
        // получить результаты измерений  
        TraceResult GetTraceResult();
    }
}