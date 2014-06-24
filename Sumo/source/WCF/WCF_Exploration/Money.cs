namespace WCF_Exploration
{
    public class Money
    {
        public Money(decimal amount, string currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}