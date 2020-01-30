using SalesTaxDeveloperTest.Services;
using System;

namespace SalesTaxDeveloperTest.Items
{
    public class ImportDutyPurchaseItem : IPurchaseItem
    {
        private readonly IPurchaseItem _purchaseItem;

        public string Description => _purchaseItem.Description;

        public decimal OriginalPrice => _purchaseItem.OriginalPrice;

        public ImportDutyPurchaseItem(IPurchaseItem purchaseItem)
        {
            _purchaseItem = purchaseItem;
        }

        public decimal GetPrice()
        {
            var importDuty = RoundingHelpers.RoundUpToNearestFivePence(_purchaseItem.OriginalPrice * 0.05m);
            return _purchaseItem.GetPrice() + importDuty;
        }
    }
}
