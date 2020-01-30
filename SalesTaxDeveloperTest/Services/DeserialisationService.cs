using SalesTaxDeveloperTest.Items;
using System.Linq;
using System.Text.RegularExpressions;

namespace SalesTaxDeveloperTest.Services
{
    public class DeserialisationService
    {
        // needs to take a text string and return purchase item and quanitity?

        public (int quantity, IPurchaseItem) CreatePurchaseItem(string item)
        {
            var trimmedItem = item.Trim();

            var numbers = Regex.Split(trimmedItem, @"[^0-9\.]+");

            var quantity = int.Parse(numbers.First());

            var price = decimal.Parse(numbers.Last());

            // this seems a bit quick and dirty and could easily break if structure changes
            // will leave as is?
            var wordsList = trimmedItem.Split(' ').Where(
                word => word != "at" &&
                !word.Any(c => char.IsDigit(c)));

            var description = string.Join(" ", wordsList);

            //first item is quantity
            return (quantity, new PurchaseItem(description, price));
        }
    }
}
