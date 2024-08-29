using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using UI.Model;

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
    private string selectedGenderAvatar = "MaleAvatar.svg";
    private bool isMaleAvatar = true;
    protected override async Task OnAfterRenderAsync(bool b)
    {
        await jsRuntime.InvokeVoidAsync("initializeCounterComponent");
    }

    private void AddParticipant()
    {
        participants.Add(new Participant(ParticipantName, ids[idIndex], x, y, selectedGenderAvatar));
        x += 25;
        y += 10;
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

    private void OnEnterPress(KeyboardEventArgs obj)
    {
        if (obj.Key == "Enter")
        {
            AddParticipant();
        }
    }
}