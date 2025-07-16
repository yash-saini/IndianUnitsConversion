using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionHistoryController : ControllerBase
    {
        private readonly ConversionHistoryService _historyService;

        public ConversionHistoryController(ConversionHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecentHistory([FromQuery] int count = 20)
        {
            var history = await _historyService.GetRecentConversionsAsync(count);
            return Ok(history);
        }

        [HttpGet("types")]
        public IActionResult GetConversionTypes()
        {
            return Ok(new[] { "Land", "Weight", "Currency", "Gold" });
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> GetHistoryByType(string type, [FromQuery] int count = 20)
        {
            if (!new[] { "Land", "Weight", "Currency", "Gold" }.Contains(type, StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid conversion type. Supported types are: Land, Weight, Currency, Gold");
            }

            var history = await _historyService.GetRecentConversionsAsync(count);
            var filteredHistory = history.Where(h =>
                h.ConversionType.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(filteredHistory);
        }
    }
}