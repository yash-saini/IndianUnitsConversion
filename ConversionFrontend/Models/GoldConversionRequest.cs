namespace ConversionFrontend.Models
{
    public class GoldConversionRequest
    {
        public double Weight { get; set; }
        public string Unit { get; set; } = "gram";
        public string Currency { get; set; } = "INR";
    }
}
