using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;

namespace Application.Services
{
    public class CreateService
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

            public async Task<Unit> Handle(Command request,CancellationToken cancellationToken)
            {
                _context.Services.Add(request.Service);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}