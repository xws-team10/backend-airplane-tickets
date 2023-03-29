using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository;
using FlyMateAPI.Core.Service.Core;

namespace FlyMateAPI.Core.Service
{
    public class TicketService : ITicketService
    {

        private readonly TicketRepository _ticketRepository;

        public TicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CreateAsync(Ticket newTicket)
        {
            await _ticketRepository.CreateAsync(newTicket);
        }

        public async Task DeleteAsync(string id) =>
            await _ticketRepository.DeleteAsync(id);

        public async Task<List<Ticket>> GetAllAsync() =>
            await _ticketRepository.GetAllAsync();

        public async Task<Ticket?> GetByIdAsync(string id) =>
            await _ticketRepository.GetbyIdAsync(id);

        public async Task UpdateAsync(string id, Ticket updateTicket) =>
            await _ticketRepository.UpdateAsync(id, updateTicket);
    }
}
