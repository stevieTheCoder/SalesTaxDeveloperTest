using SalesTaxDeveloperTest.Items;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxDeveloperTest.Services
{
    public class TaxDecoratorService
    {
        private readonly HashSet<string> _exemptItems = new HashSet<string>
        {
            "book",
            "books",
            "chocolate", 
            "chocolates",
            "pills"
        };

        public IPurchaseItem AddTax(IPurchaseItem purchaseItem)
        {
            // Check whether any word in description is in exempt list
            var isTaxExempt = _exemptItems.Any(word => purchaseItem.Description.Contains(word));

            var isImported = purchaseItem.Description.Contains("imported");

            IPurchaseItem returnItem = purchaseItem;

            if (!isTaxExempt)
            {
                returnItem = new BasicTaxPurchaseItem(returnItem);
            }

            if (isImported)
            {
                returnItem = new ImportDutyPurchaseItem(returnItem);
            }

            return returnItem;
        }
    }
}
