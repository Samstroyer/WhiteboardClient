using System.Text.Json;
using WebSocketSharp;
using Raylib_cs;

public class Engine
{
    WebSocket ws;
    Shape drawingShape = Shape.Rectangle;

    List<Paint> paintObjects = new();

    bool listLock = false;
    bool settings = false;

    public Engine()
    {
        Connect();
    }

    public void Connect()
    {
        Console.WriteLine("Enter the ip adress of host");

    Restart:
        string ip = Console.ReadLine();

        try
        {
            ws = new WebSocket("ws://" + ip + ":3000/whiteboard");
            ws.OnMessage += OnMessage_function;
            ws.Connect();
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
            if (settings) Settings();
            else
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Clicks();
                Keys();

                while (listLock) ;
                listLock = true;
                foreach (Paint p in paintObjects)
                {
                    p.Draw();
                }
                listLock = false;

                Raylib.EndDrawing();
            }
        }
    }

    private void Settings()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.BLACK);



        Raylib.EndDrawing();

        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (key == KeyboardKey.KEY_S) settings = !settings;
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

        if (key == KeyboardKey.KEY_C)
        {
            ws.Send("Clear");
            paintObjects = new();
        }
        if (key == KeyboardKey.KEY_S)
        {
            settings = !settings;
        }
    }

    private void Clicks()
    {
        var pos = Raylib.GetMousePosition();

        if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
        {
            Paint added = new(pos.X, pos.Y, (int)drawingShape);

            paintObjects.Add(added);

            string serJson = JsonSerializer.Serialize<Paint>(added);
            ws.Send(serJson);
        }
    }

    void OnMessage_function(object sender, MessageEventArgs e)
    {
        while (listLock) ;
        listLock = true;

        string data = e.Data;
        Console.WriteLine("Recieved: " + data);

        Paint p = JsonSerializer.Deserialize<Paint>(data);
        paintObjects.Add(p);

        listLock = false;
    }

}
