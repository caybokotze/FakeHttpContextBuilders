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
    }
}