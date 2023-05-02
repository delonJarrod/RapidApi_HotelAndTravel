using Microsoft.AspNetCore.Mvc;
using RapidApi_HotelAndTravel.Interfaces.BestHotel;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RapidApi_HotelAndTravel.Controllers
{
    //Intergrated with Best Booking.com Hotel from Rapid API 
    //https://rapidapi.com/PlanYourTrip/api/best-booking-com-hotel/


    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly IBestHotelLogic _bestHotelLogic;

        public HotelController(IBestHotelLogic bestHotelLogic)
        {
            _bestHotelLogic = bestHotelLogic;
        }

        [HttpPost]
        [Route("Get_Best_Hotel")]
        public async Task<ActionResult<IEnumerable<string>>> GetBestHotelInCountryAsync(string country, string city)
        {
            var body = await _bestHotelLogic.Get_BestHotelInCountry_Async(country, city);
            return Ok(body);
        }

    }
}
