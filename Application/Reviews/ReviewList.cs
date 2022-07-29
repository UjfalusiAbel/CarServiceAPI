using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Reviews
{
    public class ReviewList
    {
        public class Query:IRequest<List<Review>>
        {

        }

        public class Handler:IRequestHandler<Query, List<Review>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<List<Review>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Reviews.ToListAsync();
            }
        }
    }
}