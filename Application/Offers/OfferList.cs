using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Offers
{
    public class OfferList
    {
        public class Query : IRequest<List<Offer>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Offer>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Offer>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Offers.ToListAsync();
            }
        }
    }
}