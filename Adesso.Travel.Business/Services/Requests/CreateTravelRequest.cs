using System;
using System.Collections.Generic;

namespace Adesso.Business.Services.Travel.Requests
{
    public class CreateTravelRequest
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int ToFrom { get; set; }
        public int ToWhere { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int SeatCount { get; set; }
        public bool IsPublish { get; set; } = false;
        public List<int> NeighbourList { get; set; }
    }
}
