using ConversionAPI.Models;
using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandConversionController : ControllerBase
    {
        private readonly LandConversionService _landConversionService;
        private readonly ConversionHistoryService _historyService;

        public LandConversionController(
            LandConversionService landConversionService,
            ConversionHistoryService historyService)
        {
            _landConversionService = landConversionService;
            _historyService = historyService;
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertLandArea([FromBody] LandConversionRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.FromUnit) || string.IsNullOrEmpty(request.ToUnit))
            {
                return BadRequest("Invalid request data.");
            }
            if (request.Value < 0)
                return BadRequest("Value must be greater than zero.");
            if (request.FromUnit.ToLower() == request.ToUnit.ToLower())
            {
                return Ok(new
                {
                    ConvertedValue = request.Value,
                    request.FromUnit,
                    request.ToUnit,
                    request.LandId,
                });
            }
            try
            {
                double convertedValue = _landConversionService.ConvertLandArea(request.Value, request.FromUnit, request.ToUnit);
                await _historyService.SaveLandConversionAsync(
                     request.Value,
                     request.FromUnit,
                     convertedValue,
                     request.ToUnit);

                return Ok(new
                {
                    ConvertedValue = convertedValue,
                    request.FromUnit,
                    request.ToUnit,
                    request.LandId,
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("units")]
        public IActionResult GetSupportedUnits()
        {
            var supportedUnits = new[]
            {
                "hectare",
                "square_meter",
                "acre",
                "square_kilometer",
                "square_foot",
                "square_yard",
                "square_guz",
                "square_bigha",
                "square_feet",
                "square_yards"
            };
            return Ok(supportedUnits);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _historyService.GetRecentConversionsAsync();
            return Ok(history.Where(h => h.ConversionType == "Land"));
        }
    }
}
