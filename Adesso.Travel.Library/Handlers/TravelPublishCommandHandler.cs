using Adesso.Api.Travel.Commands;
using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Services;
using Adesso.Travel.Library.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.Travel.Library.Handlers
{
    public class TravelPublishCommandHandler : IRequestHandler<TravelPublishCommand, TravelPublishDto>
    {
        private readonly ITravelService _travelService;

        public TravelPublishCommandHandler(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public async Task<TravelPublishDto> Handle(TravelPublishCommand request, CancellationToken cancellationToken)
        {
         
            var response = await _travelService.PublishTravel(new PublishTravelRequest
            {
                Id = request.Id
            });

            return new TravelPublishDto
            {
                Id = response.Id,
                Message = response.Message
            };
        }
    }
}
