using System;

namespace SalesTaxDeveloperTest.Services
{
    public static class RoundingHelpers
    {
        /// <summary>
        /// Round up to nearest five pence
        /// </summary>
        /// <param name="value">decimal value to round</param>
        /// <returns>Rounded value</returns>
        public static decimal RoundUpToNearestFivePence(decimal value)
        {
            // Not ideal to use ceiling for rounding but should force rounding up
            return Math.Ceiling(value / 0.05m) * 0.05m;
        }
    }
}
