using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NAcceptanceRequest.Exceptions;

namespace NAcceptanceRequest.Tests
{
    [TestFixture]
    public class GetRequestTests
    {
        [Test]
        [TestCase("http://www.google.co.uk", 200, "OK")]
        [TestCase("http://www.bbc.co.uk/sport", 302, "Moved Temporarily")]
        [TestCase("http://www.google.co.uk/not-found", 404, "Not Found")]
        public void TestGetRequest(string url, int expectedStatusCode, string expectedStatusDescription)
        {
            // Arrange
            GetRequest request = new GetRequest(url);

            // Act
            request.MakeRequest();

            // Assert
            Assert.AreEqual(expectedStatusCode, request.StatusCode, "Status code");
            Assert.AreEqual(expectedStatusDescription, request.StatusDescription, "Status description");
        }

        [Test]
        public void InvalidUrl()
        {
            // Arrange, Act and Assert
            Assert.Throws<RequestFailedException>(() => { GetRequest request = new GetRequest("hytp://somewhere.blah"); });
        }

        [Test]
        public void RequestNotMade()
        {
            // Arrange
            GetRequest request = new GetRequest("http://www.somewhere.co.uk");

            // Act and Assert
            Assert.Throws<RequestNotMadeException>(() => { int i = request.StatusCode; });
        }
    }
}
