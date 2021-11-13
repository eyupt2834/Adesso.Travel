using Adesso.Travel.Library.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Adesso.Api.Travel.Commands
{
    public class TravelPublishCommand : IRequest<TravelPublishDto>
    {
         public string Id { get; set; }
    }
}
