namespace ConversionFrontend.Models
{
    public class WeightConversionResponse
    {
        public Guid WeightId { get; set; }
        public DateTime RequestDate { get; set; }
        public double Value { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double ConvertedValue { get; set; }
    }
}
