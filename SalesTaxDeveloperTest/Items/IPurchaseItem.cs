namespace SalesTaxDeveloperTest.Items
{
    public interface IPurchaseItem
    {
        public string Description { get; }
        public decimal OriginalPrice { get; }

        // method as may need calculation
        public decimal GetPrice();
    }
}
