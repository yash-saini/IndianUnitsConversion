namespace ConversionFrontend.Models
{
    public class LandConversionRequest
    {
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}
