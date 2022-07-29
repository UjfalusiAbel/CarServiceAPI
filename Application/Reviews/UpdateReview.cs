using System.Threading;
using System.Threading.Tasks;
using Persistance;
using AutoMapper;
using MediatR;
using Domain;

namespace Application.Reviews
{
    public class UpdateReview
    {
        public class Command:IRequest
        {
            public Review Review { get; set; }
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
                var review = await _context.Reviews.FindAsync(request.Review.Id);
                _mapper.Map(request.Review, review);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}