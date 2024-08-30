namespace UI.Model;

public class Participant
{
    public Participant(string name, string id, int x, int y, string avatarImg)
    {
        Time = 0;
        IsTalking = false;
        Name = name;
        Id = id;
        X = x;
        Y = y;
        AvatarImg = avatarImg;
    }

    public Action OnStopTalking { get; set; } = null!;
    public Action OnFlipTalkingState { get; set; } = null!;

    public Action OnTimeReset { get; set; } = null!;
    
    public string AvatarImg { get; set; }

    public string Name { get; set; }
    public string Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public long Time { get; set; }
    public bool IsTalking { get; set; }

    public void StopTalking()
    {
        OnStopTalking?.Invoke();
    }

    public void FlipTalkingState()
    {
        OnFlipTalkingState?.Invoke();
    }

    public void ResetTime()
    {
        Time = 0;
        OnTimeReset?.Invoke();
    }
}