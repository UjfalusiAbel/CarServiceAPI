using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Offers
{
    public class OfferListByService
    {
        public class Query : IRequest<List<Offer>>
        {
            public Guid ServiceId { get; set; }
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
                var list = await _context.Offers.ToListAsync();
                var offerListByService = from offer in list where offer.ServiceId == request.ServiceId select offer;
                return offerListByService.ToList();
            }
        }
    }
}