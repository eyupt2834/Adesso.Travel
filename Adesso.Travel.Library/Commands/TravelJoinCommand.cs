using Adesso.Travel.Library.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Adesso.Api.Travel.Commands
{
    public class TravelJoinCommand : IRequest<TravelJoinDto>
    {
        public string Id { get; set; }
        public int SeatCount { get; set; } = 1;
    }
}
