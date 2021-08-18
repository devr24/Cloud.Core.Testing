namespace Cloud.Core.Testing.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Class for faking Http responses.
    /// Implements the <see cref="DelegatingHandler" />
    /// </summary>
    /// <seealso cref="System.Net.Http.DelegatingHandler" />
    public class FakeResponseHandler : DelegatingHandler
    {
        private readonly Dictionary<Uri, HttpResponseMessage> _fakeResponses = new Dictionary<Uri, HttpResponseMessage>();

        /// <summary>
        /// Adds a fake response for a uri, with associated response message.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="responseMessage">The response message for the request.</param>
        public void AddFakeResponse(Uri uri, HttpResponseMessage responseMessage)
        {
            _fakeResponses.Add(uri, responseMessage);
        }

        /// <summary>
        /// Adds the fake response for the uri with a specific response code and data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="responseCode">The response code.</param>
        /// <param name="responseData">The response data.</param>
        public void AddFakeResponse<T>(Uri uri, HttpStatusCode responseCode, T responseData)
        {
            var response = new HttpResponseMessage(responseCode);
            var json =  System.Text.Json.JsonSerializer.Serialize(responseData);
            response.Content = new StringContent(json);
            _fakeResponses.Add(uri, response);
        }

        /// <summary>
        /// Adds the fake response for the url with a specific response code.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="responseCode">The response code.</param>
        public void AddFakeResponse(Uri uri, HttpStatusCode responseCode)
        {
            _fakeResponses.Add(uri, new HttpResponseMessage(responseCode));
        }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (_fakeResponses.ContainsKey(request.RequestUri))
            {
                return Task.FromResult(_fakeResponses[request.RequestUri]);
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound) {RequestMessage = request});
        }
    }
}
