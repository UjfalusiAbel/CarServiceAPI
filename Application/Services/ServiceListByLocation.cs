using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Services
{
    public class ServiceListByLocation
    {
        public class Query:IRequest<List<Service>> 
        {
            public string County {get; set;}
            public string Town {get;set;}
        }

        public class Handler:IRequestHandler<Query, List<Service>> 
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Service>> Handle(Query request, CancellationToken cancellationToken)
            {
                var list = await _context.Services.ToListAsync();
                var servicesLocalized = from service in list where service.County == request.County && service.Town == request.Town select service;
                return servicesLocalized.ToList();
            }
        }
    }
}