using ConversionAPI.Models;
using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightConversionController : ControllerBase
    {
        private readonly WeightConversionService _weightConversionService;
        public WeightConversionController(WeightConversionService weightConversionService)
        {
            _weightConversionService = weightConversionService;
        }

        [HttpPost("convert")]
        public IActionResult ConvertWeight([FromBody] WeightConversionRequest request)
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
                    request.WeightId,
                });
            }
            try
            {
                double convertedValue = _weightConversionService.ConvertWeight(request.Value, request.FromUnit, request.ToUnit);
                return Ok(new
                {
                    ConvertedValue = convertedValue,
                    request.FromUnit,
                    request.ToUnit,
                    request.WeightId,
                    request.RequestDate
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
                "kilogram",
                "gram",
                "pound",
                "ounce",
                "tonne",
                "stone",
                "milligram"
            };
            return Ok(supportedUnits);
        }
    }
}
