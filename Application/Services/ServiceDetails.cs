using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Services
{
    public class ServiceDetails
    {
        public class Query : IRequest<Service>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Service>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Service> Handle(Query request, CancellationToken cancellationToken)
            {
                return  await _context.Services.FindAsync(request.Id);
            }
        }
    }
}