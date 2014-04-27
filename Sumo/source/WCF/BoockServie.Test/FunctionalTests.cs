using System;
using System.Diagnostics;
using System.IO;
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
            Trace.WriteLine(Environment.CurrentDirectory);

            var process = Process.Start(".\\BookServiceStub.exe");
            if (process == null) throw new Exception();

            var wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.ReliableSession.Enabled = true;

            var client = new DbMetaManagerClient(wsHttpBinding, new EndpointAddress("http://localhost:1060/TestService"));

            var session = client.CreateQuery("");

            var sessionId = client.InnerChannel.SessionId;

            process.Kill();
            Trace.WriteLine(sessionId);
            Trace.WriteLine(session.Count.ToString());
            Assert.AreEqual(10, session.SessionId);


        }
    }
}