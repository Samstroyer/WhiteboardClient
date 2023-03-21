using System.Text.Json;
using WebSocketSharp;
using Raylib_cs;

public class Engine
{
    WebSocket ws;
    Shape drawingShape = Shape.Rectangle;

    List<Drawable> objects = new();

    public Engine()
    {
        Connect();
    }

    public void Connect()
    {
        Console.WriteLine("Enter the ip adress : port only!");
        Console.WriteLine("(Example: '100.100.100.100:3000')");

    Restart:
        string ip = Console.ReadLine();

        try
        {
            ws = new WebSocket("ws://10.151.172.192:3000/whiteboard");
            ws.Connect();
            ws.OnMessage += OnMessage_function;
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed with error: " + e);
            Console.WriteLine("Try again!");
            goto Restart;
        }
    }

    public void StartApp()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Clicks();
            Keys();

            foreach (Drawable d in objects)
            {
                d.Draw();
            }

            Raylib.EndDrawing();
        }
    }

    private void Keys()
    {
        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (key == KeyboardKey.KEY_LEFT)
        {
            int index = (int)drawingShape - 1;
            if (index < 1) index = 4;
            drawingShape = (Shape)index;
        }
        else if (key == KeyboardKey.KEY_RIGHT)
        {
            int index = (int)drawingShape + 1;
            if (index > 4) index = 1;
            drawingShape = (Shape)index;
        }

        if (key == KeyboardKey.KEY_C) ws.Send("Clear");
    }

    private void Clicks()
    {
        var pos = Raylib.GetMousePosition();

        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Drawable added = new(pos, drawingShape);
            string serJson = JsonSerializer.Serialize<Drawable>(added);
            objects.Add(added);
            ws.Send(serJson);
        }
    }

    void OnMessage_function(object sender, MessageEventArgs e)
    {
        string data = e.Data;
        Console.WriteLine("Recieved: " + data);

        objects.Add(JsonSerializer.Deserialize<Drawable>(data));
    }
}
