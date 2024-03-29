using Domain;
using System.Threading;
using System.Threading.Tasks;
using Persistance;
using MediatR;

namespace Application.Offers
{
    public class CreateOffer
    {
        public class Command : IRequest
        {
            public Offer Offer { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Offers.Add(request.Offer);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}