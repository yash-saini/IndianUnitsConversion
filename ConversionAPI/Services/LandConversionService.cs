namespace ConversionAPI.Services
{
    public class LandConversionService
    {
        public double ConvertLandArea(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
            {
                return value;
            }
            // Conversion factors
            var conversionFactors = new Dictionary<string, double>
            {
                { "hectare", 10000 }, // 1 hectare = 10,000 square meters
                { "square_meter", 1 }, // 1 square meter = 1 square meter
                { "acre", 4046.86 }, // 1 acre = 4046.86 square meters
                { "square_kilometer", 1000000 }, // 1 square kilometer = 1,000,000 square meters
                { "square_foot", 0.092903 }, // 1 square foot = 0.092903 square meters
                { "square_yard", 0.836127 }, // 1 square yard = 0.836127 square meters
                { "square_guz", 0.092903 }, // 1 square guz = 0.092903 square meters
                { "square_bigha", 2529.29 }, // 1 square bigha = 676.28 square meters
                { "square_feet", 0.092903}, // 1 square feet = 0.092903 square meters
                { "square_yards", 0.836127}, // 1 square yards = 0.836127 square meters
            };
            if (!conversionFactors.ContainsKey(fromUnit) || !conversionFactors.ContainsKey(toUnit))
            {
                throw new ArgumentException("Invalid unit provided for conversion.");
            }
            double valueInSquareMeters = value * conversionFactors[fromUnit];
            return valueInSquareMeters / conversionFactors[toUnit];
        }
    }
}
