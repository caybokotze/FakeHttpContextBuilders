using System.IO.IsolatedStorage;
using Microsoft.AspNetCore.Http;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace FakeHttpContextBuilders.Tests
{
    [TestFixture]
    public class HttpRequestBuilderTests
    {
        [Test]
        public void ShouldBeHttpRequest()
        {
            // arrange
            // act
            // assert
            Expect(typeof(FakeHttpRequest)
                .IsAssignableTo(typeof(HttpRequest))).To.Be.True();
        }

        [Test]
        public void ShouldBeValidRequest()
        {
            // arrange
            var httpRequestBuilder = new HttpRequestBuilder();
            // act
            var httpRequest = httpRequestBuilder
                .IsHttps(false)
                .WithBody(null)
                .WithCookies(null)
                .WithHeaders(null)
                .WithHost(new HostString(""))
                .WithMethod(string.Empty)
                .WithQuery(null)
                .WithPath(new PathString(""))
                .WithPathBase(new PathString(""))
                .WithScheme("")
                .WithProtocol("")
                .WithContentLength(1)
                .WithFormCollection(null)
                .WithHttpContext(null)
                .WithQueryString(new QueryString())
                .Build();
            // assert
            Expect(httpRequest.IsHttps).To.Be.False();
            Expect(httpRequest.Body).To.Be.Null();
            Expect(httpRequest.Cookies).To.Be.Null();
            Expect(httpRequest.Headers).To.Be.Null();
            Expect(httpRequest.Host).To.Be.Equal.To(new HostString(""));
            Expect(httpRequest.Method).To.Be.Equal.To("");
            Expect(httpRequest.Query).To.Be.Null();
            Expect(httpRequest.Path).To.Be.Equal.To(new PathString(""));
            Expect(httpRequest.PathBase).To.Be.Equal.To(new PathString(""));
            Expect(httpRequest.Scheme).To.Be.Equal.To("");
            Expect(httpRequest.Protocol).To.Be.Equal.To("");
            Expect(httpRequest.ContentLength).To.Be.Equal.To(1);
            Expect(httpRequest.Form).To.Be.Equal.To(null);
            Expect(httpRequest.HttpContext).To.Be.Null();
            Expect(httpRequest.QueryString).To.Be.Equal.To(new QueryString());
        }
    }
}