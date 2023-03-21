using Raylib_cs;

Engine e;

Setup();
Start();

void Setup()
{
    e = new();
    Raylib.InitWindow(1000, 800, "Draw with me!");
    Raylib.SetTargetFPS(30);
}

void Start()
{
    e.StartApp();
}
