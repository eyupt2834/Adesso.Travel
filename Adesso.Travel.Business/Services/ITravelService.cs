using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Travel.Business.Services
{
    public interface ITravelService
    {
        Task<CreateTravelResponse> CreateTravel(CreateTravelRequest request);

        Task<PublishTravelResponse> PublishTravel(PublishTravelRequest request);

        Task<DropPublishTravelResponse> DropPublishTravel(DropPublishTravelRequest request);

        Task<JoinTravelResponse> JoinTravel(JoinTravelRequest request);

        Task<List<TravelResponse>> GetTravelList(GetTravelRequest request);
    }
}
