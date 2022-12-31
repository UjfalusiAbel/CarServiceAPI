using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Reviews
{
    public class ReviewListByService
    {
        public class Query : IRequest<List<Review>>
        {
            public Guid ServiceId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Review>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Review>> Handle(Query request, CancellationToken cancellationToken)
            {
                var list = await _context.Reviews.ToListAsync();
                var reviewsByService = from review in list where review.ServiceId == request.ServiceId select review;
                return reviewsByService.ToList();
            }
        }
    }
}