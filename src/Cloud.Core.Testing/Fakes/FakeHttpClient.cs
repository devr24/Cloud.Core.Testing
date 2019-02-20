namespace Cloud.Core.Testing.Fakes
{
    using System;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Class used for faking HttpClient calls.
    /// </summary>
    public class FakeHttpClient
    {
        /// <summary>
        /// Gets the fake response handler.
        /// </summary>
        /// <value>The fake response handler.</value>
        public FakeResponseHandler FakeResponseHandler { get; } = new FakeResponseHandler();

        /// <summary>
        /// Gets the base URL set during instantiation.
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpClient" /> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public FakeHttpClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Adds an end point to the fake response handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endPoint">The end point address to add, such as 'api/v1/values'.</param>
        /// <param name="responseCode">The response code when the end point is requested.</param>
        /// <param name="responseData">The response data when the end point is requested.</param>
        public void AddEndPoint<T>(string endPoint, HttpStatusCode responseCode, T responseData)
        {
            FakeResponseHandler.AddFakeResponse(new Uri($"{BaseUrl}{endPoint}"), responseCode, responseData);
        }

        /// <summary>
        /// Adds the end point.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        /// <param name="response">The response.</param>
        public void AddEndPoint(string endPoint, HttpResponseMessage response)
        {
            FakeResponseHandler.AddFakeResponse(new Uri($"{BaseUrl}{endPoint}"), response);
        }

        /// <summary>
        /// Adds the end point.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        /// <param name="responseCode">The response code.</param>
        public void AddEndPoint(string endPoint, HttpStatusCode responseCode)
        {
            FakeResponseHandler.AddFakeResponse(new Uri($"{BaseUrl}{endPoint}"), responseCode);
        }

        /// <summary>
        /// Gets an instance of HTTP client which uses the predefined fake responses.
        /// </summary>
        /// <returns>HttpClient.</returns>
        public HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient(FakeResponseHandler)
            {
                BaseAddress = new Uri(BaseUrl)
            };
            return httpClient;
        }
    }
}
