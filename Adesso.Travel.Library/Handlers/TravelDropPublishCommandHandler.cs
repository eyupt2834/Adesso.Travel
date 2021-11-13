using Adesso.Api.Travel.Commands;
using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Services;
using Adesso.Travel.Library.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.Travel.Library.Handlers
{
    public class TravelDropPublishCommandHandler : IRequestHandler<TravelDropPublishCommand, TravelDropPublishDto>
    {
        private readonly ITravelService _travelService;

        public TravelDropPublishCommandHandler(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public async Task<TravelDropPublishDto> Handle(TravelDropPublishCommand request, CancellationToken cancellationToken)
        {
            var response = await _travelService.DropPublishTravel(new DropPublishTravelRequest
            {
                Id = request.Id
            });

            return new TravelDropPublishDto
            {
                Id = response.Id,
                Message = response.Message
            };
        }
    }
}
