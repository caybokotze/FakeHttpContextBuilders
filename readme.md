# Fake HttpContext Builders

### Usage

## Create a full http mock

```csharp

var httpContextBuilder = new HttpContextBuilder();

var httpContext = httpContextBuilder.WithItems(new Dictionary<object, object>
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
    .WithQueryString(new QueryString("?id=1"))
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
```
