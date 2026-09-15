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

    public static AvatarConfig CreateDefaultFemale() => new()
    {
        HairId = "Hair3",
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

    public string ToExportString() =>
        $"{SkinColor};{ShirtId}-{ShirtColor};{BeardId}-{BeardColor};{HairId}-{HairColor}";

    public static bool TryParseExportString(string value, out AvatarConfig config)
    {
        config = null!;
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var parts = value.Split(';');
        if (parts.Length != 4)
            return false;

        if (!TryParseStylePart(parts[1], out var shirtId, out var shirtColor))
            return false;
        if (!TryParseStylePart(parts[2], out var beardId, out var beardColor))
            return false;
        if (!TryParseStylePart(parts[3], out var hairId, out var hairColor))
            return false;

        var skinColor = parts[0];
        if (!skinColor.StartsWith('#'))
            return false;

        config = new AvatarConfig
        {
            SkinColor = skinColor,
            ShirtId = shirtId,
            ShirtColor = shirtColor,
            BeardId = beardId,
            BeardColor = beardColor,
            HairId = hairId,
            HairColor = hairColor
        };
        return true;
    }

    private static bool TryParseStylePart(string part, out string id, out string color)
    {
        id = "";
        color = "";
        var dashIndex = part.IndexOf("-#", StringComparison.Ordinal);
        if (dashIndex <= 0)
            return false;

        id = part[..dashIndex];
        color = part[(dashIndex + 1)..];
        return id.Length > 0 && color.StartsWith('#');
    }
}
