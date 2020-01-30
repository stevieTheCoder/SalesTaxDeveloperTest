namespace SalesTaxDeveloperTest.Items
{
    // Class to convert string based object to c#
    public class PurchaseItem : IPurchaseItem
    {
        public string Description { get; }

        public decimal OriginalPrice { get; }

        public PurchaseItem(string description, decimal originalPrice)
        {
            Description = description;
            OriginalPrice = originalPrice;
        }

        public decimal GetPrice()
        {
            return OriginalPrice;
        }
    }
}
