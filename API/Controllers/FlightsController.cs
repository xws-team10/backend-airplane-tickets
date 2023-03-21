using FlyMateAPI.Core.Service;
using FlyMateAPI.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace FlyMateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightsService _flightsService;

        public FlightsController(FlightsService flightsService) =>
            _flightsService = flightsService;

        [HttpGet]
        public async Task<List<Flight>> Get() =>
            await _flightsService.GetAllAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Flight>> Get(string id)
        {
            var flight = await _flightsService.GetByIdAsync(id);

            if (flight is null)
            {
                return NotFound();
            }

            return flight;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Flight newFlight)
        {
            await _flightsService.CreateAsync(newFlight);

            return CreatedAtAction(nameof(Get), new { id = newFlight.Id }, newFlight);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Flight updateFlight)
        {
            var flight = await _flightsService.GetByIdAsync(id);

            if (flight is null)
            {
                return NotFound();
            }

            updateFlight.Id = flight.Id;

            await _flightsService.UpdateAsync(id, updateFlight);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var flight = await _flightsService.GetByIdAsync(id);

            if (flight is null)
            {
                return NotFound();
            }

            await _flightsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
