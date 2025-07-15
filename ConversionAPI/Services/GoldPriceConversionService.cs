using ConversionAPI.Models;
using System.Net.Http;

namespace ConversionAPI.Services
{
    public class GoldPriceConversionService
    {
        private readonly HttpClient _httpClient;

        private static readonly Dictionary<string, double> WeightFactors = new()
        {
            { "gram", 1 },
            { "tola", 11.6638 },
            { "ounce", 31.1035 },
            { "kilogram", 1000 },
            { "pound", 453.592 },
            { "carat", 0.2 }
        };

        public GoldPriceConversionService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        public async Task<GoldPriceResponse> GetGoldPriceAsync(GoldPriceConversionRequest request)
        {
            if (!WeightFactors.ContainsKey(request.Unit.ToLower()))
                throw new ArgumentException("Unsupported unit.");

            string currency = request.Currency.ToUpper();
            var goldApi = $"https://data-asg.goldprice.org/dbXRates/{currency}";
            var goldData = await _httpClient.GetFromJsonAsync<GoldApiResponse>(goldApi);

            var pricePerOunce = goldData?.Items.FirstOrDefault()?.XauPrice ?? throw new Exception("Gold price not available");

            double pricePerGram = pricePerOunce / 31.1035;
            double gramsPerUnit = WeightFactors[request.Unit.ToLower()];
            double pricePerUnit = pricePerGram * gramsPerUnit;

            return new GoldPriceResponse
            {
                PricePerUnit = pricePerGram,
                PricePerGram = pricePerGram,
                TotalPrice = pricePerUnit * request.Weight,
                Unit = request.Unit,
                Currency = currency
            };
        }
        private class GoldApiResponse
        {
            public List<GoldItem> Items { get; set; } = new();
        }

        private class GoldItem
        {
            public double XauPrice { get; set; }
        }

        public List<string> GetSupportedCurrencies() => new() { "INR", "USD", "EUR", "GBP" };

        public List<string> GetSupportedWeightUnits() => WeightFactors.Keys.ToList();
    }
}
