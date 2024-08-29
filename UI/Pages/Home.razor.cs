using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

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
    private ElementReference myCanvas;
    private string selectedGenderAvatar = "MaleAvatar.svg";
    private bool isMaleAvatar = true;

    protected override async Task OnAfterRenderAsync(bool b)
    {
        await jsRuntime.InvokeVoidAsync("initializeCounterComponent");
    }

    private void AddParticipant()
    {
        participants.Add(new Participant(ParticipantName, ids[idIndex], x, y, selectedGenderAvatar));
        x += 200;
        y += 0;
        idIndex++;
        ParticipantName = "";
    }

    private void SwapGender()
    {
        if (isMaleAvatar)
        {
            isMaleAvatar = !isMaleAvatar;
            selectedGenderAvatar = "FemaleAvatar.svg";
        }
        else
        {
            isMaleAvatar = !isMaleAvatar;
            selectedGenderAvatar = "MaleAvatar.svg";
        }
    }

    private void StopAllOthers(string id) =>
        participants
            .Where(p => !p.Id.Equals(id))
            .ToList()
            .ForEach(p => p.StopTalking());
    
    private void HandleKeyPress(KeyboardEventArgs args)
    {
        string keyPress = args.Key;
        Participant? selectedParticipant = participants.SingleOrDefault(p => p.Id == keyPress);
        if (selectedParticipant is not null)
        {
            selectedParticipant.FlipTalkingState();
            StopAllOthers(keyPress);
        }
    }

    private async Task SetFocusToCanvas()
    {
        // await jsRuntime.InvokeVoidAsync("Focus", myCanvas);
    }

    private void OnEnterPress(KeyboardEventArgs obj)
    {
        if (obj.Key == "Enter")
        {
            AddParticipant();
        }
    }
}

public class Participant
{
    public Participant(string name, string id, int x, int y, string avatarImg)
    {
        long Time = 0;
        bool IsTalking = false;
        Name = name;
        Id = id;
        X = x;
        Y = y;
        AvatarImg = avatarImg;
    }

    public Action OnStopTalking { get; set; }
    public Action OnFlipTalkingState { get; set; }
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
}