using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi_HotelAndTravel.Interfaces.Travel;
using RapidApi_HotelAndTravel.Models;
using System.Reflection;

namespace RapidApi_HotelAndTravel.Controllers
{
    //Intergrated with IATA and ICAO Codes from Rapid API 
    //Airline Codes and Rich Content (Beta)
    //https://rapidapi.com/vacationist/api/iata-and-icao-codes/

    [ApiController]
    [Route("[controller]")]
    public class TravelController : ControllerBase
    {

        private readonly ITravel _travel;

        public TravelController(ITravel travel)
        {
            _travel = travel;
        }

        [HttpGet]
        [Route("Get_Codes")]
        public async Task<ActionResult<IEnumerable<string>>> Get_IATA_and_ICAO_Codes()
        {
            return Ok(_travel.IATA_and_ICAO_Codes());
        }

        [HttpPost]
        [Route("Search_IATA_Codes")]
        public async Task<ActionResult<IEnumerable<TravelCodes>>> Search_IATA_Codes(string search_IATA_code)
        {

            var body = await _travel.IATA_and_ICAO_Codes();
            List<TravelCodes> results = body.Where(x => x.iata_code == search_IATA_code).ToList();    
            return Ok(results);

        }
        [HttpPost]
        [Route("Search_ICAO_Codes")]
        public async Task<ActionResult<IEnumerable<TravelCodes>>> Search_ICAO_Codes(string search_ICAO_code)
        {

            var body = await _travel.IATA_and_ICAO_Codes();
            List<TravelCodes> results = body.Where(x => x.icao_code == search_ICAO_code).ToList();
            return Ok(results);

        }
    }
}
