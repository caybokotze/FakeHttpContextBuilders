using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace MockHttpContextHelpers
{
    public class HttpContextBuilder
    {
        public HttpContextBuilder()
        {
            
        }
        
        private HttpRequest _httpRequest;
        private HttpResponse _httpResponse;
        private ConnectionInfo _connectionInfo;
        private ClaimsPrincipal _user;

        public HttpContextBuilder WithRequest(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
            return this;
        }

        public HttpContextBuilder WithResponse(HttpResponse httpResponse)
        {
            _httpResponse = httpResponse;
            return this;
        }

        public HttpContextBuilder WithConnectionInfo(ConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;
            return this;
        }

        public HttpContextBuilder WithClaimsPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            _user = claimsPrincipal;
            return this;
        }

        public FakeHttpContext Build()
        {
            return new FakeHttpContext(_httpRequest, 
                _httpResponse, 
                _connectionInfo, 
                _user, 
                null, 
                null, 
                null, 
                null, 
                CancellationToken.None, 
                null, 
                null, 
                null);
        }
    }
}