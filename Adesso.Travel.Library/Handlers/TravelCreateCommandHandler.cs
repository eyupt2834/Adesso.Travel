using Adesso.Api.Travel.Commands;
using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Services;
using Adesso.Travel.Library.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.Travel.Library.Handlers
{
    public class TravelCreateCommandHandler : IRequestHandler<TravelCreateCommand, TravelCreateDto>
    {
        private readonly ITravelService _travelService;

        public TravelCreateCommandHandler(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public async Task<TravelCreateDto> Handle(TravelCreateCommand request, CancellationToken cancellationToken)
        {
            var response = await _travelService.CreateTravel(new CreateTravelRequest
            {
                ToFrom = request.ToFrom,
                ToWhere = request.ToWhere,
                Date = request.Date,
                Description = request.Description,
                SeatCount = request.SeatCount
            });

            return new TravelCreateDto
            {
                Id = response.Id
            };
        }
    }
}