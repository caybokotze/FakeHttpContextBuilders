using NUnit.Framework;

namespace FakeHttpContextBuilders.Tests
{
    [TestFixture]
    public class HttpContextBuilderTests
    {
        [Test]
        public void ShouldBuildFullHttpContext()
        {
            // arrange
            var httpContextBuilder = new HttpContextBuilder();
            // act
            httpContextBuilder
                .WithRequest()
                .WithResponse()
                .WithFeatures()
                .WithItems()
                .WithSession()
                .WithAuthenticationManager()
                .WithServiceProvider()
                .WithTraceIdentifier()
                .WithWebSocketManager()
                .WithConnectionInfo()
                .WithClaimsPrincipal()
                .WithCancellationToken()
                .Build();
            // assert
        }
    }
}