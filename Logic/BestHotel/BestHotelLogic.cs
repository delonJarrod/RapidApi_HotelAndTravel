using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi_HotelAndTravel.Interfaces.BestHotel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace RapidApi_HotelAndTravel.Logic.BestHotel
{
    public class BestHotelLogic : IBestHotelLogic
    {
        private readonly IConfiguration _mySettings;
        private static readonly HttpClient _httpClient = new HttpClient();

        public BestHotelLogic(IConfiguration mySettings)
        {
            _mySettings = mySettings;
        }

        public async Task<string> Get_BestHotelInCountry_Async(string country, string city)
        {
            //Intergrated with Best Booking.com Hotel from Rapid API 
            //https://rapidapi.com/PlanYourTrip/api/best-booking-com-hotel/

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://best-booking-com-hotel.p.rapidapi.com/booking/best-accommodation?cityName={city}&countryName={country}");
            request.Headers.Add("X-RapidAPI-Key", "1dcecfd511msha78bd4104e04264p11ee1fjsnf767f971b342");
            request.Headers.Add("X-RapidAPI-Host", "best-booking-com-hotel.p.rapidapi.com");
            using var response = _httpClient.Send(request);
            var body = await response.Content.ReadAsStringAsync();

            return body;
        }



    }
}
