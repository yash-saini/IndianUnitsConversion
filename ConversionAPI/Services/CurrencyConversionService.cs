namespace ConversionAPI.Services
{
    public class CurrencyConversionService
    {
        private readonly HttpClient _httpClient;

        public CurrencyConversionService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        public async Task<double> ConvertAsync(string from, string to, double amount)
        {
            var url = $"https://api.frankfurter.app/latest?amount={amount}&from={from}&to={to}";
            var response = await _httpClient.GetFromJsonAsync<FrankfurterResponse>(url);

            if (response == null || !response.Rates.ContainsKey(to))
                throw new ArgumentException("Failed to get exchange rate.");

            return response.Rates[to];
        }

        public List<string> GetSupportedCurrencies() =>
            new() { "USD", "EUR", "INR", "GBP", "JPY", "AUD", "CAD", "CHF" };

        public class FrankfurterResponse
        {
            public Dictionary<string, double> Rates { get; set; } = new();
        }
    }
}
