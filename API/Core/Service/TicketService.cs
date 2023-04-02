using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository;
using FlyMateAPI.Core.Service.Core;

namespace FlyMateAPI.Core.Service
{
    public class TicketService : ITicketService
    {

        private readonly TicketRepository _ticketRepository;
        private readonly FlightsRepository _flightRepository;

        public TicketService(TicketRepository ticketRepository, FlightsRepository flightsRepository)
        {
            _ticketRepository = ticketRepository;
            _flightRepository = flightsRepository;
        }

        public async Task CreateAsync(Ticket newTicket)
        {
            Flight flight = await _flightRepository.GetByIdAsync(newTicket.FlightId);
            flight.SeatsLeft -= 1;

            await _flightRepository.UpdateAsync(newTicket.FlightId, flight);
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
