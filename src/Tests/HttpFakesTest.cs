using System.Net;
using System.Net.Http;
using Cloud.Core.Testing.Fakes;
using Newtonsoft.Json;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    [IsUnit]
    public class HttpFakesTest
    {
        private const string FAKEAPIURL = "http://www.test.com/";

        /// <summary>Ensure FakeHttpClient returns the expected response data.</summary>
        [Fact]
        public void Test_HttpFakes_VerifyResponseData()
        {
            // Arrange - setup client and fake response.
            var responseData = "test";
            var fakeHttpClient = new FakeHttpClient(FAKEAPIURL);
            fakeHttpClient.AddEndPoint("api/values", HttpStatusCode.OK, responseData);
            var client = fakeHttpClient.GetHttpClient();

            // Act - make fake request and get response body.
            var response = client.GetAsync("api/values").GetAwaiter().GetResult();
            var content = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

            // Assert - response was as expected.
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(content, responseData);
        }

        /// <summary>Ensure FakeHttpClient returns the expected status code.</summary>
        [Fact]
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

        /// <summary>Ensure FakeHttpClient returns the expected HttpResponseMessage.</summary>
        [Fact]
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

        /// <summary>Ensure FakeHttpClient returns the expected response when a request to a non faked endpoint is setup.</summary>
        [Fact]
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
