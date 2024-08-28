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
        participants.Add(new Participant(ParticipantName,ids[idIndex], x, y));
        x += 200;
        y += 0;
        idIndex++;
        ParticipantName = "";
    }
}

public record Participant(string Name, string Id, int X, int Y);