using System.Threading;
using System.Threading.Tasks;
using Persistance;
using AutoMapper;
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
            public readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context=context;
                _mapper=mapper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var service = await _context.Services.FindAsync(request.Service.Id);
                _mapper.Map(request.Service, service);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}