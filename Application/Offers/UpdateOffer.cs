using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Persistance;
using AutoMapper;

namespace Application.Offers
{
    public class UpdateOffer
    {
        public class Command:IRequest
        {
            public Offer Offer { get; set; }
        }

        public class Handler:IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context=context;
                _mapper=mapper;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var offer = await _context.Offers.FindAsync(request.Offer.Id);
                _mapper.Map(request.Offer, offer);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}