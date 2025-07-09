using System.Text.Json.Serialization;

namespace ConversionAPI.Models
{
    public class CurrencyConversionRequest
    {
        [JsonIgnore]
        public Guid LandId { get; set; } = Guid.NewGuid();
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}
