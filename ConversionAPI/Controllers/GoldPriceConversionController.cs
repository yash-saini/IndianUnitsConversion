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
        public GoldPriceConversionController(GoldPriceConversionService goldPriceConversionService)
        {
            _goldPriceConversionService = goldPriceConversionService;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> GetGoldPrice([FromBody] GoldPriceConversionRequest request)
        {
            if (request.Weight <= 0)
                return BadRequest("Weight must be greater than zero.");

            try
            {
                var result = await _goldPriceConversionService.GetGoldPriceAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("units")]
        public IActionResult GetUnits() => Ok(_goldPriceConversionService.GetSupportedWeightUnits());

        [HttpGet("currencies")]
        public IActionResult GetCurrencies() => Ok(_goldPriceConversionService.GetSupportedCurrencies());
    }
}
