using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Meetings
{
    public class List
    {

        public class Query : IRequest<Result<List<Meeting>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Meeting>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Meeting>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Meeting>>.Success(await _context.Meetings.ToListAsync());
            }
        }
    }
}