using System.Text.Json.Serialization;

namespace ConversionAPI.Models
{
    public class GoldPriceConversionRequest
    {
        [JsonIgnore]
        public Guid LandId { get; set; } = Guid.NewGuid();
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public double Weight { get; set; }
        public string Unit { get; set; } = "gram";
        public string Currency { get; set; } = "INR";
    }
}
