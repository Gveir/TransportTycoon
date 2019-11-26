using Xunit;

namespace TransportTycoon.Tests
{
    public class TransportTycoonTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("A", 5)]
        [InlineData("B", 5)]
        [InlineData("AB", 5)]
        [InlineData("BB", 5)]
        [InlineData("ABB", 7)]
        [InlineData("AABABBAB", 29)]
        [InlineData("ABBBABAAABBB", 41)]
        public void AcceptanceTests(string input, uint expectedDeliveryTime)
        {
            Map map = new Map();

            map.ProcessDelivery(input);

            Assert.Equal(expectedDeliveryTime, map.ElapsedTime);
        }
    }
}
