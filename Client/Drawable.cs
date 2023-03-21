using System.Text.Json.Serialization;
using System.Numerics;
using Raylib_cs;

public enum Shape
{
    Rectangle = 1,
    Circle = 2,
    RectangleWires = 3,
    CircleWires = 4
}

public class Drawable
{
    [JsonPropertyName("pos")]
    public Vector2 Position { get; set; }

    [JsonPropertyName("shape")]
    public Shape CurrentShape { get; set; }

    public Drawable(Vector2 position, Shape shape)
    {
        Position = position;
        CurrentShape = shape;
    }

    public void Draw()
    {
        switch (CurrentShape)
        {
            case Shape.Rectangle:
                Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 10, 10, Color.RED);
                break;
            case Shape.Circle:
                Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10, Color.RED);
                break;
            case Shape.RectangleWires:
                Raylib.DrawRectangleLines((int)Position.X, (int)Position.Y, 10, 10, Color.RED);
                break;
            case Shape.CircleWires:
                Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 10, Color.RED);
                break;
        }
    }
}
