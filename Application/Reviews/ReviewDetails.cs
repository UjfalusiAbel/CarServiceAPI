using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Domain;


namespace Application.Reviews
{
    public class ReviewDetails
    {
        public class Query:IRequest<Review>
        {
            public Guid Id { get; set; }
        } 

        public class Handler:IRequestHandler<Query, Review>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context=context;
            }
            public async Task<Review> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Reviews.FindAsync(request.Id);
            }
        }
    }
}