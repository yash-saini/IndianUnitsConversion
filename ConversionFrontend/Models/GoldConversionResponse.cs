namespace ConversionFrontend.Models
{
    public class GoldConversionResponse
    {
        public Guid GoldId { get; set; }
        public DateTime RequestDate { get; set; }
        public double PricePerGram { get; set; }
        public double PricePerUnit { get; set; }
        public double TotalPrice { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
    }
}
