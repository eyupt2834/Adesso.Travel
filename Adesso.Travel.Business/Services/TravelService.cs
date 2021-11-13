using Adesso.Business.Services.Travel.Requests;
using Adesso.Travel.Business.Models;
using Adesso.Travel.Business.Services.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Travel.Business.Services
{
    public class TravelService : ITravelService
    {
        public async Task<CreateTravelResponse> CreateTravel(CreateTravelRequest request)
        {

            var jsonDataList = await Read();

            if (jsonDataList != null)
            {
                jsonDataList.Add(request);
            }
            else
            {
                jsonDataList = new List<CreateTravelRequest> { request };
            }

            var adjacent = new Adjacent();
            var adjacentList = adjacent.CreateAdjacentList(request.ToFrom, request.ToWhere);

            request.NeighbourList = adjacentList;

            await Write(jsonDataList);

            return new CreateTravelResponse
            {
                Id = request.Id
            };
        }

        public async Task<DropPublishTravelResponse> DropPublishTravel(DropPublishTravelRequest request)
        {
            var jsonDataList = await Read();

            var data = jsonDataList.FirstOrDefault(x => x.Id == request.Id);

            if (data == null) return new DropPublishTravelResponse { Id = "0", Message = "Not Found" };

            data.IsPublish = false;
            await Write(jsonDataList);

            return new DropPublishTravelResponse { Id = request.Id };
        }

        public async Task<List<TravelResponse>> GetTravelList(GetTravelRequest request)
        {
            var jsonDataList = await Read();
            jsonDataList = jsonDataList.Where(x => x.IsPublish && x.NeighbourList.Contains(request.ToFrom) && x.NeighbourList.Contains(request.ToWhere)).ToList();

            return jsonDataList.Select(item => new TravelResponse
            {
                Id = item.Id,
                ToFrom = item.ToFrom,
                ToWhere = item.ToWhere,
                Description = item.Description,
                Date = item.Date,
                SeatCount = item.SeatCount

            }).ToList();
        }

        public async Task<JoinTravelResponse> JoinTravel(JoinTravelRequest request)
        {
            var jsonDataList = await Read();
            var data = jsonDataList.FirstOrDefault(x => x.Id == request.Id);

            if (data == null) return new JoinTravelResponse { Id = "0", Message = "Not Found" };

            if (data.SeatCount < request.SeatCount) return new JoinTravelResponse { Id = "0", Message = "Seating Capacity is not available" };

            data.SeatCount = data.SeatCount - request.SeatCount;
            await Write(jsonDataList);

            return new JoinTravelResponse { Id = request.Id };
        }

        public async Task<PublishTravelResponse> PublishTravel(PublishTravelRequest request)
        {
            var jsonDataList = await Read();

            var data = jsonDataList.FirstOrDefault(x => x.Id == request.Id);

            if (data == null) return new PublishTravelResponse { Id = "0", Message = "Not Found" };

            data.IsPublish = true;
            await Write(jsonDataList);

            return new PublishTravelResponse { Id = request.Id };
        }

        #region Utils
        private async Task<List<CreateTravelRequest>> Read()
        {
            var filePath = "travels.json";
            return JsonConvert.DeserializeObject<List<CreateTravelRequest>>(await File.ReadAllTextAsync(filePath));
        }

        private async Task Write(List<CreateTravelRequest> model)
        {
            var filePath = "travels.json";
            await File.WriteAllTextAsync(filePath, JsonConvert.SerializeObject(model));
        }

        #endregion
    }
}
