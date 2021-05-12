using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Competitions
{
    public class Create
    {
        public class Command : IRequest
        {
            public Competition Competition { get; set; }
            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    _context.Competitions.Add(request.Competition);
                    await _context.SaveChangesAsync();
                    return Unit.Value;
                }
            }
        }
    }
}