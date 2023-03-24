using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using RazorLight;


namespace ReceiptFormatter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var items = new List<SaleItem>
                {
                    new SaleItem { Name = "Item1", Quantity = 1, Price = 10.0M },
                    new SaleItem { Name = "Item2", Quantity = 2, Price = 5.0M },
                    new SaleItem { Name = "Item3", Quantity = 1, Price = 15.0M },
                };
            var receipt = new Receipt()
            {
                Employee = new Employee { FirstName = "John", LastName = "Doe" },
                SaleDate = DateTime.Now,
                Store = new Store { Name = "SuperStore", Address = "123 Main St" },
                Items = items,
                TaxInfo = new TaxInfo { TaxRate = 0.10M, Items = items},
                PaymentInfo = new PaymentInfo { PaymentType = "Credit Card", Amount = 33.0M }
            };

            string receiptTemplate = @"
@model ReceiptFormatter.Receipt
@using System.Linq
========================================
Store: @Model.Store.Name
Address: @Model.Store.Address
Employee: @Model.Employee.FirstName @Model.Employee.LastName
Sale Date: @Model.SaleDate
----------------------------------------
Items:
@foreach (var item in Model.Items)
{
    //改行未対応
    Write($""{ item.Name} x { item.Quantity} - ${item.TotalPrice}<br>"");

    Write("""");//改行しない
    //提示のコード・・・動かない
    //@item.Name x @item.Quantity - $@item.TotalPrice
}

----------------------------------------
Subtotal: $@Model.Items.Sum(x => x.TotalPrice)
Tax (@Model.TaxInfo.TaxRate * 100)%: $@Model.TaxInfo.TaxAmount
Total: $@(Model.Items.Sum(x => x.TotalPrice) + Model.TaxInfo.TaxAmount)
----------------------------------------
Payment: @Model.PaymentInfo.PaymentType
Amount: $@Model.PaymentInfo.Amount
========================================";

            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program))
                .UseMemoryCachingProvider()
                .Build();

            string result = await engine.CompileRenderStringAsync("templateKey", receiptTemplate, receipt);
            Console.WriteLine(result.Replace("&lt;br&gt;","\n"));
        }
    }
}
