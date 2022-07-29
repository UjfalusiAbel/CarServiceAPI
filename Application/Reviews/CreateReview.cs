using Domain;
using System.Threading;
using System.Threading.Tasks;
using Persistance;
using MediatR;

namespace Application.Reviews
{
    public class CreateReview
    {
        public class Command: IRequest
        {
            public Review Review { get; set; }
        }

        public class Handler:IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Reviews.Add(request.Review);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}