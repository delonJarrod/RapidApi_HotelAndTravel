using RapidApi_HotelAndTravel.Models;

namespace RapidApi_HotelAndTravel.Interfaces.Travel
{
    public interface ITravel
    {
        public Task<List<TravelCodes>> IATA_and_ICAO_Codes();
    }
}
