namespace ConversionAPI.Services
{
    public class WeightConversionService
    {
        public double ConvertWeight(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == toUnit)
            {
                return value;
            }
            // Conversion factors
            var conversionFactors = new Dictionary<string, double>
            {
                { "kilogram", 1 }, // 1 kilogram = 1 kilogram
                { "gram", 0.001 }, // 1 gram = 0.001 kilograms
                { "pound", 0.453592 }, // 1 pound = 0.453592 kilograms
                { "ounce", 0.0283495 }, // 1 ounce = 0.0283495 kilograms
                { "tonne", 1000 }, // 1 tonne = 1000 kilograms
                { "stone", 6.35029 }, // 1 stone = 6.35029 kilograms
                { "milligram", 0.000001 } // 1 milligram = 0.000001 kilograms
            };
            if (!conversionFactors.ContainsKey(fromUnit) || !conversionFactors.ContainsKey(toUnit))
            {
                throw new ArgumentException("Invalid unit provided for conversion.");
            }
            double valueInKilograms = value * conversionFactors[fromUnit];
            return valueInKilograms / conversionFactors[toUnit];
        }
    }
}
