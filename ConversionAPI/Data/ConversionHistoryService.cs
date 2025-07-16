using ConversionAPI.Data;

namespace ConversionAPI.Services
{
    public class ConversionHistoryService
    {
        private readonly ConversionDbContext _context;

        public ConversionHistoryService(ConversionDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> SaveLandConversionAsync(double inputValue, string fromUnit, double outputValue, string toUnit)
        {
            var history = new ConversionHistory
            {
                ConversionDate = DateTime.UtcNow,
                Id = new Guid(),
                ConversionType = "Land",
                InputValue = inputValue.ToString(),
                InputUnit = fromUnit,
                OutputValue = outputValue.ToString(),
                OutputUnit = toUnit
            };

            _context.ConversionHistories.Add(history);
            await _context.SaveChangesAsync();
            return history.Id;
        }

        public async Task<Guid> SaveWeightConversionAsync(double inputValue, string fromUnit, double outputValue, string toUnit)
        {
            var history = new ConversionHistory
            {
                ConversionDate = DateTime.UtcNow,
                Id = new Guid(),
                ConversionType = "Weight",
                InputValue = inputValue.ToString(),
                InputUnit = fromUnit,
                OutputValue = outputValue.ToString(),
                OutputUnit = toUnit
            };

            _context.ConversionHistories.Add(history);
            await _context.SaveChangesAsync();
            return history.Id;
        }

        public async Task<Guid> SaveCurrencyConversionAsync(double amount, string fromCurrency, double convertedAmount, string toCurrency)
        {
            var history = new ConversionHistory
            {
                ConversionDate = DateTime.UtcNow,
                Id = new Guid(),
                ConversionType = "Currency",
                InputValue = amount.ToString(),
                InputUnit = fromCurrency,
                OutputValue = convertedAmount.ToString(),
                OutputUnit = toCurrency
            };

            _context.ConversionHistories.Add(history);
            await _context.SaveChangesAsync();
            return history.Id;
        }

        public async Task<Guid> SaveGoldPriceAsync(double weight, string unit, string currency, double totalPrice)
        {
            var history = new ConversionHistory
            {
                ConversionDate = DateTime.UtcNow,
                Id = new Guid(),
                ConversionType = "Gold",
                InputValue = weight.ToString(),
                InputUnit = unit,
                OutputValue = totalPrice.ToString(),
                OutputUnit = currency
            };

            _context.ConversionHistories.Add(history);
            await _context.SaveChangesAsync();
            return history.Id;
        }

        public async Task<List<ConversionHistory>> GetRecentConversionsAsync(int count = 10)
        {
            return _context.ConversionHistories
                .OrderByDescending(h => h.ConversionDate)
                .Take(count)
                .ToList();
        }
    }
}