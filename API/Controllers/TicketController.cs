using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Service;
using FlyMateAPI.Core.Service.Core;
using Microsoft.AspNetCore.Mvc;

namespace FlyMateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<List<Ticket>> Get() =>
           await _ticketService.GetAllAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Ticket>> Get(string id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (ticket is null)
            {
                return NotFound();
            }

            return ticket;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket newTicket)
        {
            await _ticketService.CreateAsync(newTicket);

            return CreatedAtAction(nameof(Get), new { id = newTicket.Id }, newTicket);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Ticket updateTicket)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (ticket is null)
            {
                return NotFound();
            }
            updateTicket.Id = ticket.Id;

            await _ticketService.UpdateAsync(id, updateTicket);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (ticket is null)
            {
                return NotFound();
            }

            await _ticketService.DeleteAsync(id);

            return NoContent();
        }
    }
}
