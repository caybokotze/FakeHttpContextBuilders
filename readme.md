# Fake HttpContext Builders

### Usage

```csharp
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
```
