using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Meetings
{
    public class Update
    {

        public class Command : IRequest<Result<Unit>>
        {
            public Meeting Meeting { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Meeting).SetValidator(new MeetingValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {

            private readonly DataContext _context;
            public IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var meeting = await _context.Meetings.FindAsync(request.Meeting.Id);

                if (meeting == null) return null;

                _mapper.Map(request.Meeting, meeting);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Faliure("Failed to update meeting!");

                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}