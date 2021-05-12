using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Competitions
{
    public class Details
    {
        public class Query: IRequest<Competition>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Competition>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Competition> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Competitions.FindAsync(request.Id); 
            }
        }
    }
}