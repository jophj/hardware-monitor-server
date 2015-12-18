using HttpServer;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            new DataConfiguration().ConfigureWebServer();
        }
    }
}
