﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Travel.Business.Services.Response
{
    public class TravelResponse
    {
        public string Id { get; set; }
        public int ToFrom { get; set; }
        public int ToWhere { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int SeatCount { get; set; }
    }
}
