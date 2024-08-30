namespace UI.Model;

public record Avatar(
    string Face,
    RGB FaceColor,
    string Hair,
    RGB HairColor,
    string Shirt,
    RGB ShirtColor);
    
public record RGB(int R, int G, int B);