using SalesTaxDeveloperTest.Services;

namespace SalesTaxDeveloperTest.Items
{
    public class BasicTaxPurchaseItem : IPurchaseItem
    {
        private readonly IPurchaseItem _purchaseItem;

        public string Description => _purchaseItem.Description;

        public decimal OriginalPrice => _purchaseItem.OriginalPrice;

        public BasicTaxPurchaseItem(IPurchaseItem purchaseItem)
        {
           _purchaseItem = purchaseItem;
        }

        public decimal GetPrice()
        {
            var tax = RoundingHelpers.RoundUpToNearestFivePence(_purchaseItem.OriginalPrice * 0.1m);
            return _purchaseItem.GetPrice() + tax;
        }
    }
}
