using System.Threading;
using Tracer.Print;
using TracerLib.Serialization;
using TracerLib.Tracer;

namespace Tracer
{
    public class MainApp
    {
        private static void Main(string[] args)
        {
            var program = new MainApp();
            var thread = new Thread(program.Method);
            ITracer tracer = new TracerLib.Tracer.Tracer();
            
            var foo = new Foo(tracer);
            foo.MyMethod();
            thread.Start(tracer);
            thread.Join();
            
            var result = new VXmlSerializer().Serialize(tracer.GetTraceResult());
            IPrinter filePrinter = new FilePrinter(PathHolder.XmlPath);
            IPrinter consolePrinter = new ConsolePrinter();
            
            filePrinter.PrintResult(result);
            consolePrinter.PrintResult(result);
            
            result = new JsonSerializer().Serialize(tracer.GetTraceResult());
            filePrinter = new FilePrinter(PathHolder.JsonPath);
            
            filePrinter.PrintResult(result);
            consolePrinter.PrintResult(result);
        }
        public class Foo
        {
            private Bar _bar;
            private ITracer _tracer;

            internal Foo(ITracer tracer)
            {
                _tracer = tracer;
                _bar = new Bar(_tracer);
            }

            public void MyMethod()
            {
                _tracer.StartTrace();
                _bar.InnerMethod();
                _tracer.StopTrace();
            }
        }

        public class Bar
        {
            private ITracer _tracer;

            internal Bar(ITracer tracer)
            {
                _tracer = tracer;
            }

            public void InnerMethod()
            {
                _tracer.StartTrace();

                Thread.Sleep(100);
                _tracer.StopTrace();
            }
        }

        public void Method(object o)
        {
            var tracer = (TracerLib.Tracer.Tracer) o;
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}