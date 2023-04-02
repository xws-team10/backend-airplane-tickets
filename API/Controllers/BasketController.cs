using FlyMateAPI.Core.Model;
using FlyMateAPI.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly BasketService _basketService;
        private readonly FlightsService _flightsService;

        public BasketController(BasketService basketService, FlightsService flightsService)
        {
            _basketService = basketService;
            _flightsService = flightsService;
        }
        /*
        [HttpGet]
        public async Task<ActionResult<List<Basket>>> Get()
        {
            return await _basketService.GetAllAsync();
        }*/
        
        [HttpGet(Name = "UserBasket")]
        public async Task<ActionResult<Basket>> GetUserBasket()
        {
            var basket = await _basketService.GetBasket("aa");

            if (basket == null) return NotFound();

            return Ok(basket);
        }
        /*
        [HttpPost]
        public async Task<ActionResult<Basket>> AddTicketToBasket(string ticketId)
        {
            var basket = await _basketService.GetBasket("aa");

            if (basket == null) basket = await _basketService.CreateBasket();

            var flight = await _flightsService.GetByIdAsync(ticketId);

            if (flight == null) return BadRequest(new ProblemDetails { Title = "Flight Not Found" });

            _basketService.AddTicket(flight);

            return basket;

        }
        */
        /*
        [HttpDelete]
        public async Task<ActionResult> RemoveTicketFromBasket(int ticketId)
        {
            var basket = await _basketService.GetBasket("aa");

            if (basket == null) return NotFound();

            basket.RemoveItem(ticketId);

        }*/

    }
}
