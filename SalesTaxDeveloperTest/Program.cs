using SalesTaxDeveloperTest.Output;
using System;
using System.IO;

namespace SalesTaxDeveloperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiptCreator = new ReceiptCreator(new Services.DeserialisationService(), new Services.TaxDecoratorService());

            // Test reading files from bin directory
            var directory = Directory.GetCurrentDirectory();

            var files = Directory.GetFiles(Path.Join(directory, @"Scenarios"), "*.txt");

            foreach (var file in files)
            {
                var lines = File.ReadAllLines(file);

                Receipt receipt = receiptCreator.CreateReceipt(lines);

                Console.WriteLine(receipt.ToString());
            }

            Console.ReadKey();
        }
    }
}
