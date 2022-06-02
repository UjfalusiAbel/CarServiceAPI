using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;

namespace Application.Offers
{
    public class OfferDetails
    {
        public class Query : IRequest<Offer>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Offer>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Offer> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Offers.FindAsync(request.Id);
            }
        }
    }
}