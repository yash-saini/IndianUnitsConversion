using ConversionAPI.Models;
using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoldPriceConversionController : ControllerBase
    {
        private readonly GoldPriceConversionService _goldPriceConversionService;
        private readonly ConversionHistoryService _historyService;

        public GoldPriceConversionController(GoldPriceConversionService goldPriceConversionService, ConversionHistoryService historyService)
        {
            _goldPriceConversionService = goldPriceConversionService;
            _historyService = historyService;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> GetGoldPrice([FromBody] GoldPriceConversionRequest request)
        {
            if (request.Weight <= 0)
                return BadRequest("Weight must be greater than zero.");

            try
            {
                var result = await _goldPriceConversionService.GetGoldPriceAsync(request);
                await _historyService.SaveGoldPriceAsync(request.Weight, request.Unit, request.Currency, result.TotalPrice);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _historyService.GetRecentConversionsAsync();
            return Ok(history.Where(h => h.ConversionType == "Gold"));
        }

        [HttpGet("units")]
        public IActionResult GetUnits() => Ok(_goldPriceConversionService.GetSupportedWeightUnits());

        [HttpGet("currencies")]
        public IActionResult GetCurrencies() => Ok(_goldPriceConversionService.GetSupportedCurrencies());
    }
}
