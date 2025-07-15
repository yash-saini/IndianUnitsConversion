using ConversionAPI.Models;
using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyConversionController : ControllerBase
    {
        private readonly CurrencyConversionService _currencyConversionService;
        public CurrencyConversionController(CurrencyConversionService currencyConversionService)
        {
            _currencyConversionService = currencyConversionService;
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCurrency([FromBody] CurrencyConversionRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.FromCurrency) || string.IsNullOrEmpty(request.ToCurrency))
            {
                return BadRequest("Invalid request data.");
            }
            if (request.Amount <= 0)
            {
                return BadRequest("Amount must be greater than zero.");
            }
            if (request.FromCurrency.ToLower() == request.ToCurrency.ToLower())
            {
                return Ok(new
                {
                    ConvertedAmount = request.Amount,
                    request.FromCurrency,
                    request.ToCurrency,
                    request.RequestDate
                });
            }
            try
            {
                double convertedAmount = await _currencyConversionService.ConvertAsync(request.FromCurrency, request.ToCurrency, request.Amount);
                return Ok(new
                {
                    ConvertedAmount = convertedAmount,
                    request.FromCurrency,
                    request.ToCurrency,
                    request.RequestDate
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("currencies")]
        public IActionResult GetSupportedCurrencies()
        {
            var supportedCurrencies = _currencyConversionService.GetSupportedCurrencies();
            return Ok(supportedCurrencies);
        }
    }
}
