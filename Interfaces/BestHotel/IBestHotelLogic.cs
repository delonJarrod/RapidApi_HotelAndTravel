namespace RapidApi_HotelAndTravel.Interfaces.BestHotel
{
    public interface IBestHotelLogic
    {
        Task<string> Get_BestHotelInCountry_Async(string country, string city);
    }
}
