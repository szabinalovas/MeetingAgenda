using Application.Meetings;
using Domain;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    public class MeetingController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetMeetings()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeeting(Guid id)
        {
            var result = await Mediator.Send(new Details.Query { Id = id });
            return HandleResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting(Meeting meeting)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Meeting = meeting }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeeting(Guid id, Meeting meeting)
        {
            meeting.Id = id;
            return HandleResult(await Mediator.Send(new Update.Command { Meeting = meeting }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}