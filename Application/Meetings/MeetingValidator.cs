
using Domain;
using FluentValidation;

namespace Application.Meetings
{
    public class MeetingValidator : AbstractValidator<Meeting>
    {
        public MeetingValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Room).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();
        }
    }
}