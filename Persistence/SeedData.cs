using Domain;

namespace Persistence
{
    public class SeedData
    {
        public static async Task SeedDatas(DataContext context)
        {
            if (context.Meetings.Any()) return;

            var meetings = new List<Meeting>
            {
                new Meeting
                {
                    Title = "Team Time",
                    Room = "Room Nr. 205",
                    Date = DateTime.UtcNow.AddDays(2),
                    StartTime = "13:00",
                    EndTime = "14:00",
                },
                new Meeting
                {
                    Title = "Retro",
                    Room = "Room Nr. 209",
                    Date = DateTime.UtcNow.AddDays(1),
                    StartTime = "9:00",
                    EndTime = "10:00",
                },
                new Meeting
                {
                    Title = "Refinement",
                    Room = "Room Nr. 205",
                    Date = DateTime.UtcNow.AddDays(3),
                    StartTime = "15:00",
                    EndTime = "16:00",
                },
                new Meeting
                {
                    Title = "Review",
                    Room = "Room Nr. 204",
                    Date = DateTime.UtcNow.AddDays(1),
                    StartTime = "13:00",
                    EndTime = "14:00",
                }
            };

            await context.Meetings.AddRangeAsync(meetings);
            await context.SaveChangesAsync();
        }
    }
}