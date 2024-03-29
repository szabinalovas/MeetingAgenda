using Application.Core;
using MediatR;
using Persistence;

namespace Application.Meetings
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var meeting = await _context.Meetings.FindAsync(request.Id);

                if (meeting == null) return null;

                _context.Remove(meeting);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Faliure("Failed to update meeting!");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}