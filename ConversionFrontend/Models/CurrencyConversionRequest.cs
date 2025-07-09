namespace ConversionFrontend.Models
{
    public class CurrencyConversionRequest
    {
        public double Amount { get; set; }
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
    }
}
