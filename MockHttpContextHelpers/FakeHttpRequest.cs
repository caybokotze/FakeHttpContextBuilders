using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace MockHttpContextHelpers
{
    public class HttpRequestBuilder
    {
        private HttpContext _httpContext;
        private string _method;
        private string _scheme;
        private bool _isHttps;
        private HostString _host;
        private PathString _pathBase;
        private PathString _path;
        private QueryString _queryString;
        private IQueryCollection _query;
        private string _protocol;
        private IHeaderDictionary _headers;
        private IRequestCookieCollection _cookies;
        private long? _contentLength;
        private string _contentType;
        private Stream _body;
        private bool _hasFormContentType;
        private IFormCollection _form;

        public HttpRequestBuilder WithHttpContext(HttpContext httpContext)
        {
            _httpContext = httpContext;
            return this;
        }

        public HttpRequestBuilder WithMethod(string method)
        {
            _method = method;
            return this;
        }

        public HttpRequestBuilder WithScheme(string sheme)
        {
            _scheme = sheme;
            return this;
        }

        public HttpRequestBuilder IsHttps(bool isHttps)
        {
            _isHttps = isHttps;
            return this;
        }

        public HttpRequestBuilder WithHost(HostString host)
        {
            _host = host;
            return this;
        }

        public HttpRequestBuilder WithPathBase(PathString pathBase)
        {
            _pathBase = pathBase;
            return this;
        }

        public HttpRequestBuilder WithPath(PathString path)
        {
            _path = path;
            return this;
        }

        public HttpRequestBuilder WithQueryString(QueryString queryString)
        {
            _queryString = queryString;
            return this;
        }

        public HttpRequestBuilder WithQuery(QueryCollection query)
        {
            _query = query;
            return this;
        }

        public HttpRequestBuilder WithProtocol(string protocol)
        {
            _protocol = protocol;
            return this;
        }

        public HttpRequestBuilder WithHeaders(IHeaderDictionary headers)
        {
            _headers = headers;
            return this;
        }

        public HttpRequestBuilder WithCookies(IRequestCookieCollection cookies)
        {
            _cookies = cookies;
            return this;
        }

        public HttpRequestBuilder WithContentLength(long contentLength)
        {
            _contentLength = contentLength;
            return this;
        }

        public HttpRequestBuilder WithContentType(string contentType)
        {
            _contentType = contentType;
            return this;
        }

        public HttpRequestBuilder WithBody(Stream body)
        {
            _body = body;
            return this;
        }

        public HttpRequestBuilder HasFormContentType(bool hasFormContentType)
        {
            _hasFormContentType = hasFormContentType;
            return this;
        }

        public HttpRequestBuilder WithFormCollection(IFormCollection form)
        {
            _form = form;
            return this;
        }
        
        public FakeHttpRequest Build()
        {
            return new FakeHttpRequest(
                _httpContext, 
                _method, 
                _scheme, 
                _isHttps, 
                _host, 
                _pathBase, 
                _path, 
                _queryString,
                _query, 
                _protocol, 
                _headers, 
                _cookies, 
                _contentType, 
                _body, 
                _contentLength, 
                _hasFormContentType, 
                _form);
        }
    }
    
    public class FakeHttpRequest : HttpRequest
    {
        public FakeHttpRequest(
                HttpContext httpContext,
                string method,
                string scheme,
                bool isHttps,
                HostString host,
                PathString pathBase,
                PathString path,
                QueryString queryString,
                IQueryCollection query,
                string protocol,
                IHeaderDictionary headers,
                IRequestCookieCollection cookies,
                string contentType,
                Stream body,
                long? contentLength,
                bool hasFormContentType,
                IFormCollection form)
        {
            HttpContext = httpContext;
            Method = method;
            Scheme = scheme;
            IsHttps = isHttps;
            Host = host;
            PathBase = pathBase;
            Path = path;
            QueryString = queryString;
            Query = query;
            Protocol = protocol;
            Headers = headers;
            Cookies = cookies;
            ContentLength = contentLength;
            ContentType = contentType;
            Body = body;
            HasFormContentType = hasFormContentType;
            Form = form;
        }
        
        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override HttpContext HttpContext { get; }
        public override string Method { get; set; }
        public override string Scheme { get; set; }
        public override bool IsHttps { get; set; }
        public override HostString Host { get; set; }
        public override PathString PathBase { get; set; }
        public override PathString Path { get; set; }
        public override QueryString QueryString { get; set; }
        public override IQueryCollection Query { get; set; }
        public override string Protocol { get; set; }
        public override IHeaderDictionary Headers { get; }
        public override IRequestCookieCollection Cookies { get; set; }
        public override long? ContentLength { get; set; }
        public override string ContentType { get; set; }
        public override Stream Body { get; set; }
        public override bool HasFormContentType { get; }
        public override IFormCollection Form { get; set; }
    }
}