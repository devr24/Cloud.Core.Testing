using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cloud.Core.Testing.Fakes;
using Newtonsoft.Json;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    public class HttpFakesTest
    {
        private const string FAKEAPIURL = "http://www.test.com/";

        [Fact, IsUnit]
        public void Test_HttpFakes_TestWithData()
        {
            var data = "test";

            // Arrange - setup client and fake response.
            var fakeHttpClient = new FakeHttpClient(FAKEAPIURL);
            fakeHttpClient.AddEndPoint("api/values", HttpStatusCode.OK, data);
            var client = fakeHttpClient.GetHttpClient();

            // Act - make fake request and get response body.
            var response = client.GetAsync("api/values").GetAwaiter().GetResult();
            var content = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            // Assert - response was as expected.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(content, data);
        }

        [Fact, IsUnit]
        public void Test_HttpFakes_TestStatusOnly()
        {
            // Arrange - setup client and fake response.
            var fakeHttpClient = new FakeHttpClient(FAKEAPIURL);
            fakeHttpClient.AddEndPoint("api/values", HttpStatusCode.NoContent);
            var client = fakeHttpClient.GetHttpClient();

            // Act - make fake request.
            var response = client.GetAsync("api/values").GetAwaiter().GetResult();

            // Assert - response was as expected.
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact, IsUnit]
        public void Test_HttpFakes_TestWithResponse()
        {
            // Arrange - setup client and fake response.
            var fakeHttpClient = new FakeHttpClient(FAKEAPIURL);
            fakeHttpClient.AddEndPoint("api/values", new HttpResponseMessage(HttpStatusCode.OK));
            var client = fakeHttpClient.GetHttpClient();

            // Act - make fake request.
            var response = client.GetAsync("api/values").GetAwaiter().GetResult();

            // Assert - response was as expected.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact, IsUnit]
        public void Test_HttpFakes_DoesNotExist()
        {
            // Arrange - setup client and fake response.
            var fakeHttpClient = new FakeHttpClient(FAKEAPIURL);
            fakeHttpClient.AddEndPoint("api/values", HttpStatusCode.OK);
            var client = fakeHttpClient.GetHttpClient();

            // Act - make fake request.
            var response = client.GetAsync("anotherEndpoint").GetAwaiter().GetResult();

            // Assert - response was as expected.
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
