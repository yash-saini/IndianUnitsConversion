namespace ConversionAPI.Models
{
    public class GoldPriceResponse
    {
        public double PricePerGram { get; set; }
        public double TotalPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
    }
}
