using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Services;
using Adesso.Travel.Library.Dtos;
using Adesso.Travel.Library.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adesso.Travel.Library.Handlers
{
    public class TravelResearchQueryHandler : IRequestHandler<TravelResearchQuery, List<TravelResearchDto>>
    {
        private readonly ITravelService _travelService;
        public TravelResearchQueryHandler(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public async Task<List<TravelResearchDto>> Handle(TravelResearchQuery request, CancellationToken cancellationToken)
        {
            var response = await _travelService.GetTravelList(new GetTravelRequest
            {
                ToFrom = request.ToFrom,
                ToWhere = request.ToWhere
            });

            return response.Select(item => new TravelResearchDto
            {
                Id = item.Id,
                ToFrom = item.ToFrom,
                ToWhere = item.ToWhere,
                Description = item.Description,
                Date = item.Date,
                SeatCount = item.SeatCount
            }).ToList();
        }
    }
}
