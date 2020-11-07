using System.Threading;
using NUnit.Framework;
using TracerLib.Tracer;

namespace TracerTests
{
    [TestFixture]
    public class TestClass
    {
        private readonly ITracer _tracer = new Tracer(); 
        
        [Test]
        public void TestTreeStructure()
        {
            _tracer.StartTrace();
            _method1();
            _method2();
            _method3();
            _tracer.StopTrace();

            var methodInfoArr = _tracer.GetTraceResult().GetThreadTraces()[Thread.CurrentThread.ManagedThreadId].MethodInfo[0];

            Assert.AreEqual("_method1", methodInfoArr.ChildMethods[0].MethodName);
            Assert.AreEqual("_method2", methodInfoArr.ChildMethods[1].MethodName);
                Assert.AreEqual("_method4", methodInfoArr.ChildMethods[1].ChildMethods[0].MethodName);
            Assert.AreEqual("_method3", methodInfoArr.ChildMethods[2].MethodName);
            
        }
        
        public void _method1()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }
        public void _method2()
        {
            _tracer.StartTrace();
            _method4(); 
            _tracer.StopTrace();
        }
        public void _method3()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }
        public void _method4()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }

    }
}