using Microsoft.AspNetCore.Http;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace FakeHttpContextBuilders.Tests
{
    [TestFixture]
    public class ConnectionBuilderTests
    {
        [Test]
        public void ShouldBeConnectionInfo()
        {
            // arrange
            // act
            // assert
            Expect(typeof(FakeConnection)
                .IsAssignableTo(typeof(ConnectionInfo))).To.Be.True();
        }
    }
}