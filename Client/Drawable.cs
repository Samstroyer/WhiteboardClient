// // using System.Text.Json.Serialization;
// // using System.Numerics;
// // using Raylib_cs;

// // public enum Shape
// // {
// //     Rectangle = 1,
// //     Circle = 2,
// //     RectangleWires = 3,
// //     CircleWires = 4
// // }

// public class Drawable
// {
//     [JsonPropertyName("x")]
//     public string X { get; set; } = "100";

//     [JsonPropertyName("y")]
//     public string Y { get; set; } = "100";

//     [JsonPropertyName("shape")]
//     public int ShapeNumber
//     {
//         get
//         {
//             return (int)shape;
//         }
//         set
//         {
//             shape = (Shape)value;
//         }
//     }

//     [JsonIgnore]
//     public Shape shape = Shape.Circle;
//     [JsonIgnore]
//     public Vector2 Position { get; set; }

//     public Drawable(Vector2 position, Shape _shape)
//     {
//         Position = position;
//         shape = _shape;
//     }

//     public void Draw()
//     {
//         switch (shape)
//         {
//             case Shape.Rectangle:
//                 Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 10, 10, Color.RED);
//                 break;
//             case Shape.Circle:
//                 Raylib.DrawCircle((int)Position.X, (int)Position.Y, 10, Color.RED);
//                 break;
//             case Shape.RectangleWires:
//                 Raylib.DrawRectangleLines((int)Position.X, (int)Position.Y, 10, 10, Color.RED);
//                 break;
//             case Shape.CircleWires:
//                 Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 10, Color.RED);
//                 break;
//         }
//     }
// }
