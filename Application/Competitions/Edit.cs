using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Competitions
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Competition Competition { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }


            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var competition = await _context.Competitions.FindAsync(request.Competition.Id);
                _mapper.Map(request.Competition, competition);
                await _context.SaveChangesAsync();
                return Unit.Value;

            }
        }
    }
}