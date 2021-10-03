using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using static NExpect.Expectations;

namespace FakeHttpContextBuilders.Tests
{
    [TestFixture]
    public class HttpResponseBuilderTests
    {
        [Test]
        public void ShouldBeHttpResponse()
        {
            // arrange
            // act
            // assert
            Expect(typeof(FakeHttpResponse).IsAssignableTo(typeof(HttpResponse)));
        }

        [Test]
        public void ShouldBeValidResponse()
        {
            // arrange
            
            // act
            // assert
        }
    }
}