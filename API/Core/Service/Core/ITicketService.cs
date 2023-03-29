using FlyMateAPI.Core.Model;

namespace FlyMateAPI.Core.Service.Core
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(string id);
        Task CreateAsync(Ticket newTicket);
        Task UpdateAsync(string id, Ticket updateTicket);
        Task DeleteAsync(string id);
    }
}
