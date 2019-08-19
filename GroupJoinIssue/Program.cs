using System;
using System.Linq;

namespace GroupJoinIssue
{
    public static class Program
    {
        static void Main()
        {
            // Create database context and seed data if empty.
            var databaseContext = new DatabaseContext();
            Seed(databaseContext);

            // Join operation
            var joinResults =
                databaseContext.Invoices
                    .Join(
                        databaseContext.Companies,
                        x => x.CompanyId,
                        y => y.Id,
                        (x, y) => new
                        {
                            InvoiceNumber = x.Number,
                            CompanyName = y.Name,
                        });
            Console.WriteLine("Join results:");
            foreach(var x in joinResults)
            {
                Console.WriteLine($"Invoice number {x.InvoiceNumber} belongs to {x.CompanyName}.");
            }
            Console.WriteLine();

            // GroupJoin operation
            var groupJoinResults =
                databaseContext.Invoices
                    .GroupJoin(
                        databaseContext.Products,
                        x => x.Id,
                        y => y.InvoiceId,
                        (x, y) => new
                        {
                            InvoiceNumber = x.Number,
                            ProductNames = y.Select(z => z.Name)
                        });
            Console.WriteLine("GroupJoin results:");
            foreach (var x in groupJoinResults)
            {
                Console.WriteLine($"Invoice number {x.InvoiceNumber} has products: {string.Join(", ", x.ProductNames)}.");
            }
            Console.WriteLine();

            // Join and GroupJoin operation
            // Notice, that GroupJoin doesn't work as expected.
            // It returns one row for each product instead of grouping all products for invoice.
            // Results:
            // Invoice number 1 belongs to IT Company and has products: Laptop.
            // Invoice number 1 belongs to IT Company and has products: System configuration.
            // Invoice number 2 belongs to IT Company and has products: .
            var joinAndGroupJoinResults =
                databaseContext.Invoices
                    .Join(
                        databaseContext.Companies,
                        x => x.CompanyId,
                        y => y.Id,
                        (x, y) => new
                        {
                            InvoiceId = x.Id,
                            InvoiceNumber = x.Number,
                            CompanyName = y.Name,
                        })
                    .GroupJoin(
                        databaseContext.Products,
                        x => x.InvoiceId,
                        y => y.InvoiceId,
                        (x, y) => new
                        {
                            x.InvoiceNumber,
                            x.CompanyName,
                            ProductNames = y.Select(z => z.Name)
                        });
            Console.WriteLine("Join and GroupJoin results:");
            foreach (var x in joinAndGroupJoinResults)
            {
                Console.WriteLine($"Invoice number {x.InvoiceNumber} belongs to {x.CompanyName} and has products: {string.Join(", ", x.ProductNames)}.");
            }
            Console.WriteLine();

            // Delay end of the program.
            Console.ReadKey();
        }

        static void Seed(DatabaseContext databaseContext)
        {
            if (databaseContext.Companies.Any() || databaseContext.Invoices.Any() || databaseContext.Products.Any())
            {
                return;
            }

            // Create company
            databaseContext.Companies.Add(
                new Company
                {
                    Name = "IT Company",
                });
            databaseContext.SaveChanges();

            // Create invoices
            var companyId =
                databaseContext.Companies
                    .Where(x => x.Name == "IT Company")
                    .Select(x => x.Id)
                    .First();
            databaseContext.Invoices.Add(
                new Invoice
                {
                    CompanyId = companyId,
                    Number = "1"
                });
            databaseContext.Invoices.Add(
                new Invoice
                {
                    CompanyId = companyId,
                    Number = "2"
                });
            databaseContext.SaveChanges();

            // Create products
            var invoiceId1 =
                databaseContext.Invoices
                    .Where(x => x.Number == "1")
                    .Select(x => x.Id)
                    .First();
            databaseContext.Products.Add(
                new Product
                {
                    InvoiceId = invoiceId1,
                    Name = "Laptop",
                });
            databaseContext.Products.Add(
                new Product
                {
                    InvoiceId = invoiceId1,
                    Name = "System configuration",
                });
            databaseContext.SaveChanges();
        }
    }
}
