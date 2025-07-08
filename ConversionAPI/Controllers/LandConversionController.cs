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
        public LandConversionController(LandConversionService landConversionService)
        {
            _landConversionService = landConversionService;
        }

        [HttpPost("convert")]
        public IActionResult ConvertLandArea([FromBody] LandConversionRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.FromUnit) || string.IsNullOrEmpty(request.ToUnit))
            {
                return BadRequest("Invalid request data.");
            }
            try
            {
                double convertedValue = _landConversionService.ConvertLandArea(request.Value, request.FromUnit, request.ToUnit);
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
        {   var supportedUnits = new[]
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
    }
}
