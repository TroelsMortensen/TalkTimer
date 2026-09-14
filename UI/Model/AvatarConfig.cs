namespace UI.Model;

public class AvatarConfig
{
    public const string None = "none";

    public string HairId { get; set; } = None;
    public string BeardId { get; set; } = None;
    public string ShirtId { get; set; } = "Shirt1";

    public string HairColor { get; set; } = "#4A3728";
    public string BeardColor { get; set; } = "#4A3728";
    public string ShirtColor { get; set; } = "#2E5A88";
    public string SkinColor { get; set; } = "#F0C8A0";

    public static AvatarConfig CreateDefaultMale() => new()
    {
        HairId = "Hair1",
        BeardId = None,
        ShirtId = "Shirt1",
        HairColor = "#4A3728",
        BeardColor = "#4A3728",
        ShirtColor = "#2E5A88",
        SkinColor = "#F0C8A0"
    };

    public AvatarConfig Clone() => new()
    {
        HairId = HairId,
        BeardId = BeardId,
        ShirtId = ShirtId,
        HairColor = HairColor,
        BeardColor = BeardColor,
        ShirtColor = ShirtColor,
        SkinColor = SkinColor
    };
}
