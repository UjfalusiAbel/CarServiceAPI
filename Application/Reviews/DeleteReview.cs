using System;
using System.Threading;
using System.Threading.Tasks;
using Persistance;
using MediatR;
using Domain;

namespace Application.Reviews
{
    public class DeleteReview
    {
        public class Command:IRequest
        {
            public Guid Id{ get; set; }
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
                var review = await _context.Reviews.FindAsync(request.Id);
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}