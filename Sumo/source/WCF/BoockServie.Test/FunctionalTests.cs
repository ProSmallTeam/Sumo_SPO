using System.Diagnostics;
using System.ServiceModel;
using BoockServie.Test.BoockServiceStub;
using NUnit.Framework;

namespace BoockServie.Test
{
    [TestFixture]
    public class FunctionalTests
    {
        [Test]
        public void SetUp()
        {
        }

        [Test]
        public void Test()
        {

            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            var client = new DbMetaManagerClient(wsHttpBinding, new EndpointAddress("http://localhost:1060/TestService"));

            var session = client.CreateQuery("");

            var sessionId = client.InnerChannel.SessionId;
            Trace.WriteLine(sessionId);
            Trace.WriteLine(session.Count.ToString());
            Assert.AreEqual(10, session.SessionId);
            
        }
    }
}