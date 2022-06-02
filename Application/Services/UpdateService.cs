using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Persistance;
using MediatR;
using Domain;

namespace Application.Services
{
    public class UpdateService
    {
        public class Command:IRequest
        {
            public Service Service { get; set;}
        }

        public class Handler:IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var service = await _context.Services.FindAsync(request.Service.Id);
                service.Name = request.Service.Name ?? service.Name;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}