﻿using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Repository;
using FlyMateAPI.Core.Service.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;




namespace FlyMateAPI.Core.Service
{
    public class FlightsService : IFlightsService
    {
        private readonly FlightsRepository _repository;
        private readonly TicketRepository _ticketRepository;

        public FlightsService(FlightsRepository repository, TicketRepository ticketRepository)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Flight>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<Flight> GetByIdAsync(string id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Flight newFlight) =>
            await _repository.CreateAsync(newFlight);

        public async Task UpdateAsync(string id, Flight updateFlight) =>
            await _repository.UpdateAsync(id, updateFlight);

        public async Task DeleteAsync(string id) =>
            await _repository.DeleteAsync(id);

        public async Task<List<Flight>> GetPurchased(string email)
        {
            List<Flight> PurchasedFlight = new List<Flight>();

            foreach (Ticket ticket in await _ticketRepository.GetAllAsync())
            {
                if (ticket != null && ticket.UserId.Equals(email))
                {
                    PurchasedFlight.Add(await _repository.GetByIdAsync(ticket.FlightId));
                }
            }
            return PurchasedFlight;
        }

        public async Task<List<Flight>> GetBySearch(int capacity, DateTime date, string from, string to)
        {
            List<Flight> FlightsBySearch = new List<Flight>();
            foreach (Flight flight in await GetAllAsync())
            {
                if (flight.SeatsLeft >= capacity)
                    if (DateTime.Compare(flight.DepartureDateTime.Date, date.Date) == 0 || date.Date.Equals(DateTime.MinValue))
                        if ((flight.From.ToLower()).StartsWith(from.ToLower()) || from == "")
                            if ((flight.To.ToLower()).StartsWith(to.ToLower()) || to == "")
                                FlightsBySearch.Add(flight);
            }
            return FlightsBySearch;
        }

    }
}