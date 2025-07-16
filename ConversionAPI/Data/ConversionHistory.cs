using System.ComponentModel.DataAnnotations;

namespace ConversionAPI.Data
{
    public class ConversionHistory
    {
        [Key]
        public Guid Id { get; set; }
        public string ConversionType { get; set; } = string.Empty; // "Land", "Weight", "Currency", "Gold"
        public DateTime ConversionDate { get; set; } = DateTime.UtcNow;
        public string InputValue { get; set; } = string.Empty;
        public string InputUnit { get; set; } = string.Empty;
        public string OutputValue { get; set; } = string.Empty;
        public string OutputUnit { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty; // For future authentication
    }
}
