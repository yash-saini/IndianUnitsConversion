namespace ConversionFrontend.Models
{
    public class CurrencyConversionResponse
    {
        public Guid WeightId { get; set; }
        public DateTime RequestDate { get; set; }
        public double Amount { get; set; }
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public double ConvertedAmount { get; set; }
    }
}
