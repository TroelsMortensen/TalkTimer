using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    private string[] ids =
    [
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "Q", "W", "E", "R", "T"
    ];

    private string ParticipantName { get; set; } = string.Empty;
    private int x = 10;
    private int y = 200;
    private int idIndex = 0;
    private List<Participant> participants = [];

    private void AddParticipant()
    {
        participants.Add(new Participant(ParticipantName, ids[idIndex], x, y));
        x += 200;
        y += 0;
        idIndex++;
        ParticipantName = "";
    }
}

public class Participant
{
    public Participant(string name, string id, int x, int y)
    {
        long Time = 0;
        bool IsTalking = false;
        Name = name;
        Id = id;
        X = x;
        Y = y;
    }

    public string Name { get; set; }
    public string Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public long Time { get; set; }
    public bool IsTalking { get; set; }
}