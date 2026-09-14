namespace UI.Model;

public static class AvatarCatalog
{
    public const string FacePath = "images/avatar/face/Face.svg";
    public const string NeckPath = "images/avatar/face/Neck.svg";

    public static readonly IReadOnlyList<string> HairStyles =
    [
        AvatarConfig.None,
        "Hair1"
    ];

    public static readonly IReadOnlyList<string> BeardStyles =
    [
        AvatarConfig.None
    ];

    public static readonly IReadOnlyList<string> ShirtStyles =
    [
        "Shirt1"
    ];

    public static readonly IReadOnlyList<string> StyleColors =
    [
        "#1A1A1A",
        "#4A3728",
        "#C4A35A",
        "#8B4513",
        "#8A8A8A",
        "#2E5A88",
        "#2E7D4F",
        "#A12B2B"
    ];

    public static readonly IReadOnlyList<string> SkinColors =
    [
        "#FFE0BD",
        "#F0C8A0",
        "#E0AC69",
        "#C68642",
        "#A56B3D",
        "#8D5524",
        "#5C3A21",
        "#3B2214"
    ];

    public static string? HairPath(string id) =>
        id == AvatarConfig.None ? null : $"images/avatar/hair/{id}.svg";

    public static string? BeardPath(string id) =>
        id == AvatarConfig.None ? null : $"images/avatar/beard/{id}.svg";

    public static string ShirtPath(string id) => $"images/avatar/shirt/{id}.svg";

    public static IReadOnlyList<string> StylesFor(AvatarCategory category) => category switch
    {
        AvatarCategory.Hair => HairStyles,
        AvatarCategory.Beard => BeardStyles,
        AvatarCategory.Shirt => ShirtStyles,
        _ => []
    };
}

public enum AvatarCategory
{
    Beard,
    Hair,
    Shirt
}
