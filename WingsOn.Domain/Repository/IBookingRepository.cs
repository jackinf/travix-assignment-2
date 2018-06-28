namespace WingsOn.Domain.Repository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking GetByFlightNumber(string flightNumber);
    }
}