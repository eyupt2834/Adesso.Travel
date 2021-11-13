using Adesso.Travel.Library.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Travel.Library.Queries
{
    public class TravelResearchQuery : IRequest<List<TravelResearchDto>>
    {
        public int ToFrom { get; set; }
        public int ToWhere { get; set; }
    }
}
