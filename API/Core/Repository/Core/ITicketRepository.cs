using FlyMateAPI.Core.Model;

namespace FlyMateAPI.Core.Repository.Core
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket?> GetbyIdAsync(string id);
        Task CreateAsync(Ticket newTicket);
        Task UpdateAsync(string id, Ticket updateTicket);
        Task DeleteAsync(string id);
    }
}
