using UI.Model;

namespace UI.Services;

public class ParticipantsService
{
    private static readonly string[] Ids =
    [
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "Q", "W", "E", "R", "T"
    ];

    public List<Participant> participants = [];

    private int x = 10;
    private int y = 200;
    private int idIndex;

    public bool CanAdd => idIndex < Ids.Length;

    public bool Add(string name, AvatarConfig avatar)
    {
        if (!CanAdd)
            return false;

        participants.Add(new Participant(name, Ids[idIndex], x, y, avatar.Clone()));
        x += 25;
        y += 10;
        idIndex++;
        return true;
    }
}
