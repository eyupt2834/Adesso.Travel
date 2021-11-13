using System;

namespace Adesso.Travel.Library.Dtos
{
    public class TravelResearchDto
    {
        public string Id { get; set; }

        public int ToFrom { get; set; }

        public int ToWhere { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int SeatCount { get; set; }

    }
}
