using SalesTaxDeveloperTest.Output;
using SalesTaxDeveloperTest.Services;
using System.Collections.Generic;

namespace SalesTaxDeveloperTest
{
    public class ReceiptCreator
    {
        private readonly DeserialisationService _deserialisationService;
        private readonly TaxDecoratorService _taxDecoratorService;

        public ReceiptCreator(DeserialisationService deserialisationService,
            TaxDecoratorService taxDecoratorService)
        {
            _deserialisationService = deserialisationService;
            _taxDecoratorService = taxDecoratorService;
        }

        public Receipt CreateReceipt(IList<string> textItems)
        {
            var receipt = new Receipt();

            // each item will be on a new line so can call deserialisation service
            foreach (var textItem in textItems)
            {
                var (quantity, purchaseItem) = _deserialisationService.CreatePurchaseItem(item: textItem);

                for (int i = 0; i < quantity; i++)
                {
                    var itemWithTax = _taxDecoratorService.AddTax(purchaseItem);
                    receipt.AddPurchaseItem(itemWithTax);
                }
            }

            return receipt;
        }
    }
}
