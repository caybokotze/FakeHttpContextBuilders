using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Primitives;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace FakeHttpContextBuilders.Tests
{
    [TestFixture]
    public class HttpContextBuilderTests
    {
        [Test]
        public void ShouldBuildBasicHttpContext()
        {
            // arrange
            var httpContextBuilder = new HttpContextBuilder();
            // act
            var httpContext = httpContextBuilder
                .WithRequest(null)
                .WithResponse(null)
                .WithFeatures(new FeatureCollection())
                .WithItems(null)
                .WithSession(null)
                .WithAuthenticationManager(null)
                .WithServiceProvider(null)
                .WithTraceIdentifier(string.Empty)
                .WithWebSocketManager(new DefaultWebSocketManager(new FeatureCollection()))
                .WithConnectionInfo(new DefaultConnectionInfo(new FeatureCollection()))
                .WithClaimsPrincipal(new ClaimsPrincipal())
                .WithCancellationToken(new CancellationToken(false))
                .Build();
            // assert
            Expect(httpContext).To.Not.Be.Null();
            Expect(httpContext.Items).To.Be.Null();
            Expect(httpContext.Request).To.Be.Null();
            Expect(httpContext.Response).To.Be.Null();
            Expect(httpContext.Features).Not.To.Be.Null();
            Expect(httpContext.Session).To.Be.Null();
            Expect(httpContext.Authentication).To.Be.Null();
            Expect(httpContext.RequestServices).To.Be.Null();
            Expect(httpContext.TraceIdentifier).To.Be.Equal.To("");
            Expect(httpContext.WebSockets).Not.To.Be.Null();
            Expect(httpContext.Connection).Not.To.Be.Null();
            Expect(httpContext.User).Not.To.Be.Null();
            Expect(httpContext.RequestAborted).Not.To.Be.Null();
        }

        [Test]
        public void ShouldBuildValidHttpContext()
        {
            // arrange
            var httpContextBuilder = new HttpContextBuilder();
            // act
            var httpContext = httpContextBuilder.WithItems(new Dictionary<object, object?>
                {
                    {
                        new {Name = "Michael"},
                        new {Surname = "Watson"}
                    }
                }).WithRequest(new HttpRequestBuilder()
                    .WithBody(new MemoryStream(Encoding.ASCII.GetBytes("this is an example stream")))
                    .WithPath(new PathString("/the path to elderado"))
                    .WithCookies(new RequestCookieCollection(new Dictionary<string, string>
                    {
                        {"auth", "secret1234"}
                    }))
                    .WithHeaders(new HeaderDictionary(new Dictionary<string, StringValues>
                    {
                        {"auth", "anotherSecret1234"}
                    }))
                    .WithMethod("GET")
                    .WithQueryString(new QueryString("?id = 23"))
                    .WithProtocol("HTTPS")
                    .WithContentLength(4)
                    .HasFormContentType(false)
                    .Build())
                .WithResponse(new HttpResponseBuilder()
                    .WithHttpStatusCode(200)
                    .WithHeaders(new HeaderDictionary(new Dictionary<string, StringValues>()
                    {
                        {"auth", "secret12345"},
                        {"another", "coffee"}
                    }))
                    .HasStarted(true)
                    .WithContentLength(34)
                    .WithContentType("XML")
                    .WithResponseCookies(new ResponseCookies(new HeaderDictionary(new Dictionary<string, StringValues>
                    {
                        {"red", "wine"}
                    }), new DefaultObjectPool<StringBuilder>(new StringBuilderPooledObjectPolicy())))
                    .Build())
                .WithClaimsPrincipal(new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim("user", "John"),
                    new Claim("password", "birthdate")
                })))
                .WithConnectionInfo(new ConnectionBuilder()
                    .WithId("23")
                    .WithLocalPort(4433)
                    .WithRemotePort(5454)
                    .WithLocalIpAddress(new IPAddress(new byte[]{ 192, 168, 1, 2 }))
                    .WithRemoteIpAddress(new IPAddress(new byte[]{ 192, 168, 1, 2 }))
                    .WithClientCertificate(new X509Certificate2())
                    .Build())
                .Build();
            // assert
            Expect(httpContext).To.Not.Be.Null();
            Expect(httpContext.Connection.Id).To.Be.Equal.To("23");
        }
    }
}