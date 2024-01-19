namespace Domain;

public class Meeting
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Room { get; set; }
    public DateTime Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}
