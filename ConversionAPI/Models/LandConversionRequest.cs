using System.Text.Json.Serialization;

namespace ConversionAPI.Models
{
    public class LandConversionRequest
    {
        [JsonIgnore]
        public Guid LandId { get; set; } = Guid.NewGuid();
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}
