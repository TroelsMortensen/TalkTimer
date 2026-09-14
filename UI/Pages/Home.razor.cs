using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using UI.Model;
using UI.Services;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    [Inject] public ParticipantsService ParticipantsService { get; set; }

    private string ParticipantName { get; set; } = string.Empty;
    private AvatarConfig selectedAvatar = AvatarConfig.CreateDefaultMale();
    private bool showAvatarEditor;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("initializeCounterComponent");
    }

    private void AddParticipant()
    {
        if (!ParticipantsService.Add(ParticipantName, selectedAvatar))
            return;

        ParticipantName = "";
    }

    private void OpenAvatarEditor() => showAvatarEditor = true;

    private void CloseAvatarEditor() => showAvatarEditor = false;

    private void OnAvatarConfirmed(AvatarConfig config)
    {
        selectedAvatar = config;
        showAvatarEditor = false;
    }

    private void StopAllOthers(string id) =>
        ParticipantsService.participants
            .Where(p => !p.Id.Equals(id))
            .ToList()
            .ForEach(p => p.StopTalking());

    private void HandleKeyPress(KeyboardEventArgs args)
    {
        string keyPress = args.Key;
        Participant? selectedParticipant = ParticipantsService.participants.SingleOrDefault(p => p.Id == keyPress);
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
