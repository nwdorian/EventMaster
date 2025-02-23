namespace EventMaster.WebApi.Models;

public class Event
{
    /// <summary>
    /// The unique identifier for the event.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the event.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The date of the event.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The location of the event.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// The list of speakers for the event.
    /// </summary>
    public List<string>? Speakers { get; set; }
}
