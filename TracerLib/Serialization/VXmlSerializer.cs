﻿using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using TracerLib.Tracer;
using Formatting = System.Xml.Formatting;

namespace TracerLib.Serialization
{
    public class VXmlSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var data = traceResult.GetThreadTraces().Values.ToArray();
            var xmlSerializer = new XmlSerializer(data.GetType());
            var stringWriter = new StringWriter();
            
            using (var writer = new XmlTextWriter(stringWriter))
            {
                writer.Formatting = Formatting.Indented;
                xmlSerializer.Serialize(writer, data);
            }

            var result = stringWriter.ToString().Replace("ArrayOfThread", "root");

            return result;
            }
        }
    }
    
    
