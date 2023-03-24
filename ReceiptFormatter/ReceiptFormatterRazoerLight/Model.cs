namespace ReceiptFormatter
{

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Store
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Receipt
    {
        public DateTime SaleDate { get; set; }
        public Employee Employee { get; set; }
        public Store Store { get; set; }
        public List<SaleItem> Items { get; set; }
        public TaxInfo TaxInfo { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }

    public class SaleItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Quantity * Price;
    }

    public class TaxInfo
    {
        public decimal TaxRate { get; set; }
        public decimal TaxAmount => Items.Sum(x => x.TotalPrice) * TaxRate;
        public List<SaleItem> Items { get; set; }
    }

    public class PaymentInfo
    {
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
    }
}
