using SalesTaxDeveloperTest.Services;
using Xunit;

namespace SalesTaxDeveloperTests
{
    public class RoundingTests
    {
        [Theory]
        [InlineData(1.499,1.5)]
        [InlineData(0.5625, 0.6)]
        [InlineData(1.899, 1.9)]
        public void RoundToFivePence_Returns_CorrectValue(decimal value, decimal expected)
        {
            Assert.Equal(expected, RoundingHelpers.RoundUpToNearestFivePence(value));
        }
    }
}
