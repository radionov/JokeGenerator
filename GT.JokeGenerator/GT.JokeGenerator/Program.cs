using System;
using System.Threading;
using System.Threading.Tasks;

namespace GT.JokeGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            JokeLoop loop = new JokeLoop();

            Console.WriteLine("Press ? to get instructions.");
            if (Console.ReadLine() == "?")
            {
                await loop.StartLoopAsync(cancellationTokenSource.Token);
            }

            Console.WriteLine("Application stopped!");
        }
    }
}
