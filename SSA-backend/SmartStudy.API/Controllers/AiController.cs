using Microsoft.AspNetCore.Mvc;
using SmartStudy.Application.Interfaces;

namespace SmartStudy.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiController : ControllerBase
    {
        private readonly IAiService _aiService;

        public AiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] AiRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Prompt))
                return BadRequest("Prompt cannot be empty.");

            var result = await _aiService.GenerateTextAsync(request.Prompt);
            return Ok(new { response = result });
        }
    }

    public class AiRequest
    {
        public string Prompt { get; set; } = "";
    }
}