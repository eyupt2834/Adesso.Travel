namespace Adesso.Business.Services.Travel.Requests
{
    public class JoinTravelRequest
    {
        public string Id { get; set; }
        public int SeatCount { get; set; } = 1;
    }
}
