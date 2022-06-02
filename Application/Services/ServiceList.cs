using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Services
{
    public class ServiceList
    {
        public class Query:IRequest<List<Service>>
        {

        }

        public class Handler:IRequestHandler<Query, List<Service>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            public async Task<List<Service>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Services.ToListAsync();
            }
        }
    }
}