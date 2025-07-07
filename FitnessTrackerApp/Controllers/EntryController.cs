using FitnessTrackerApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ILogger<EntryController> _logger;
        private readonly IEntryService _entryService; 

        public EntryController(IEntryService entryService, ILogger<EntryController> logger)
        {
            _entryService = entryService;
            _logger = logger;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetEntriesForUser(string id)
        {
            var entries = await _entryService.GetEntriesForUserAsync(id);
            return Ok(entries);
        }
    }
}
