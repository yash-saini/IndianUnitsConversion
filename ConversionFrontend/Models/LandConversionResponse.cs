namespace ConversionFrontend.Models
{
    public class LandConversionResponse
    {
        public Guid LandId { get; set; }
        public DateTime RequestDate { get; set; }
        public double Value { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double ConvertedValue { get; set; }
    }
}
