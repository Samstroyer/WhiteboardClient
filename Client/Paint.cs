using System.Text.Json.Serialization;
using System.Text.Json;
using System.Numerics;
using Raylib_cs;

// Funny name - Paint.cs

public enum Shape
{
    Rectangle = 1,
    Circle = 2,
    RectangleWires = 3,
    CircleWires = 4
}

public class Paint
{
    [JsonPropertyName("x")]
    public float X { get; set; }

    [JsonPropertyName("y")]
    public float Y { get; set; }

    public Paint(float x, float y)
    {
        X = x;
        Y = y;
    }

    public void Draw()
    {
        Raylib.DrawCircle((int)X, (int)Y, 10, Color.RED);
    }
}
