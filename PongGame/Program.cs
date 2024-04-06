
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace PongGame;
internal class Program : GameWindow
{
  
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        using(Program program = new Program(800, 600, "test"))
        {
            program.Run();
        }
    }
}
