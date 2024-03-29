using Application.Core;
using Domain;
using MediatR;
using Persistence;


namespace Application.Meetings
{
    public class Details
    {
        public class Query : IRequest<Result<Meeting>>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Result<Meeting>>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Meeting>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Meetings.FindAsync(request.Id);

                return Result<Meeting>.Success(result);
            }
        }

    }
}