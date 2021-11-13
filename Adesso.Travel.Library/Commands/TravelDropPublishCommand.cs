using Adesso.Travel.Library.Dtos;
using MediatR;

namespace Adesso.Api.Travel.Commands
{
    public class TravelDropPublishCommand : IRequest<TravelDropPublishDto>
    {
        public string Id { get; set; }
    }
}
