using SalesTaxDeveloperTest.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxDeveloperTest.Output
{
    public class Receipt
    {
        public IList<IPurchaseItem> PurchaseItems { get; } = new List<IPurchaseItem>();
        public decimal SalesTaxes { get; private set; }
        public decimal Total { get; private set; }

        // Adds item and increases sales tax and total with item details
        public void AddPurchaseItem(IPurchaseItem purchaseItem)
        {
            PurchaseItems.Add(purchaseItem);
            SalesTaxes += purchaseItem.GetPrice() - purchaseItem.OriginalPrice;
            Total += purchaseItem.GetPrice();
        }

        // Need method to print in right format so for brevity will ovveride tostring
        public override string ToString()
        {
            var builder = new StringBuilder();

            // group by description, use annon object for brevity
            var items = PurchaseItems
                .GroupBy(item => item.Description)
                .Select(group => new
                {
                    Count = group.Count(),
                    Description = group.Key,
                    Price = group.Sum(i => i.GetPrice())
                });

            // need to consider how quantity works
            foreach (var purchaseItem in items)
            {
                // hard code pound as no other currencies, not ideal
                builder.AppendLine($"{purchaseItem.Count} {purchaseItem.Description}: £{purchaseItem.Price}");
            }

            // Add footer
            builder.AppendLine($"Sales Taxes: £{SalesTaxes}");
            builder.AppendLine($"Total: £{Total}");

            return builder.ToString();
        }
    }
}
