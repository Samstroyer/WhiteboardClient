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

    [JsonPropertyName("shape")]
    public int ShapeNum { get; set; }

    public Paint(float x, float y, int shapeNum)
    {
        X = x;
        Y = y;
        ShapeNum = shapeNum;
    }

    public void Draw()
    {
        switch (ShapeNum)
        {
            case 1:
                Raylib.DrawRectangle((int)X, (int)Y, 10, 10, Color.RED);
                break;
            case 2:
                Raylib.DrawCircle((int)X, (int)Y, 10, Color.RED);
                break;
            case 3:
                Raylib.DrawRectangleLines((int)X, (int)Y, 10, 10, Color.RED);
                break;
            case 4:
                Raylib.DrawCircleLines((int)X, (int)Y, 10, Color.RED);
                break;

            default:
                Console.WriteLine("No state on");
                Raylib.DrawCircle((int)X, (int)Y, 10, Color.RED);
                break;
        }
    }
}
