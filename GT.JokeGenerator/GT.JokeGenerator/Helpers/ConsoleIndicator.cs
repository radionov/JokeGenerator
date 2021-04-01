using System;
using System.Threading;
using System.Threading.Tasks;

namespace GT.JokeGenerator.Helpers
{
    public class ConsoleIndicator
    {
        /// <summary>Waits the asynchronous.</summary>
        /// <param name="token">The cancellation token.</param>
        public static async Task WaitAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                foreach (var symbol in new[] { '/', '\\' })
                {
                    Console.Write(symbol);
                    await Task.Delay(100);
                    Clear();
                }
            }
        }

        /// <summary>Clears this instance.</summary>
        public static void Clear()
        {
            if (Console.CursorLeft > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }
}
