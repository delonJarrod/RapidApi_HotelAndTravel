using Newtonsoft.Json;
using RapidApi_HotelAndTravel.Interfaces.BestHotel;
using RapidApi_HotelAndTravel.Interfaces.Travel;
using RapidApi_HotelAndTravel.Models;
using System.Diagnostics.Metrics;

namespace RapidApi_HotelAndTravel.Logic.Travel
{
    public class Travel : ITravel
    {
        private readonly IConfiguration _mySettings;
        private static readonly HttpClient _httpClient = new HttpClient();

        public Travel(IConfiguration mySettings)
        {
            _mySettings = mySettings;
        }


        public async Task<List<TravelCodes>> IATA_and_ICAO_Codes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://iata-and-icao-codes.p.rapidapi.com/airlines");
            request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
            request.Headers.Add("X-RapidAPI-Host", "iata-and-icao-codes.p.rapidapi.com");
            using var response = _httpClient.Send(request);
            var body = await response.Content.ReadAsStringAsync();
            string returnValue = response.Content.ReadAsStringAsync().Result;
            List<TravelCodes> results = JsonConvert.DeserializeObject<List<TravelCodes>>(body) ?? new List<TravelCodes>();
            return results;

        }

    }
}
