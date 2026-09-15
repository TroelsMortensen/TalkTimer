using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using UI.Model;
using UI.Services;

namespace UI.Pages;

public partial class Home : ComponentBase
{
    private enum AvatarPreset
    {
        Male,
        Female,
        Custom
    }

    [Inject] public ParticipantsService ParticipantsService { get; set; }

    private string ParticipantName { get; set; } = string.Empty;
    private readonly AvatarConfig defaultMaleAvatar = AvatarConfig.CreateDefaultMale();
    private readonly AvatarConfig defaultFemaleAvatar = AvatarConfig.CreateDefaultFemale();
    private AvatarConfig? customAvatar;
    private AvatarConfig selectedAvatar = AvatarConfig.CreateDefaultMale();
    private AvatarPreset selectedPreset = AvatarPreset.Male;
    private bool showAvatarEditor;
    private string? draggingParticipantId;

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

    private void SelectMalePreset()
    {
        selectedPreset = AvatarPreset.Male;
        selectedAvatar = defaultMaleAvatar;
    }

    private void SelectFemalePreset()
    {
        selectedPreset = AvatarPreset.Female;
        selectedAvatar = defaultFemaleAvatar;
    }

    private void SelectCustomPreset()
    {
        if (customAvatar is null)
            return;

        selectedPreset = AvatarPreset.Custom;
        selectedAvatar = customAvatar;
    }

    private void OpenAvatarEditor() => showAvatarEditor = true;

    private void CloseAvatarEditor() => showAvatarEditor = false;

    private void OnAvatarConfirmed(AvatarConfig config)
    {
        customAvatar = config.Clone();
        selectedPreset = AvatarPreset.Custom;
        selectedAvatar = customAvatar;
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

    private void OnCardDragStarted(string participantId) =>
        draggingParticipantId = participantId;

    private void OnCanvasMouseMove(MouseEventArgs e)
    {
        if (draggingParticipantId is null)
            return;

        var participant = ParticipantsService.participants
            .SingleOrDefault(p => p.Id == draggingParticipantId);
        if (participant is null)
            return;

        // Offsets keep the card roughly under the cursor relative to the avatar.
        participant.Y = (int)(e.ClientY - 130);
        participant.X = (int)(e.ClientX - 90);
    }

    private void OnCanvasMouseUp(MouseEventArgs e) =>
        draggingParticipantId = null;
}
