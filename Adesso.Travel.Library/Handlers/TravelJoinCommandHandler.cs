using Adesso.Api.Travel.Commands;
using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Services;
using Adesso.Travel.Library.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.RideShare.Api.Application.Travel.Commands.TravelJoin
{
    public class TravelJoinCommandHandler : IRequestHandler<TravelJoinCommand, TravelJoinDto>
    {
        private readonly ITravelService _travelService;

        public TravelJoinCommandHandler(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public async Task<TravelJoinDto> Handle(TravelJoinCommand request, CancellationToken cancellationToken)
        {
            var response = await _travelService.JoinTravel(new JoinTravelRequest
            {
                Id = request.Id,
                SeatCount = request.SeatCount
            });

            return new TravelJoinDto
            {
                Id = response.Id,
                Message = response.Message
            };
        }
    }
}
