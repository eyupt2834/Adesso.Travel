using Adesso.Travel.Library.Dtos;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Adesso.Api.Travel.Commands
{
    public class TravelCreateCommand : IRequest<TravelCreateDto>
    {
       public int ToFrom { get; set; }
       public int ToWhere { get; set; }
       public DateTime Date { get; set; } = DateTime.Now;
       public string Description { get; set; }
       public int SeatCount { get; set; } = 1;
    }
}
