using System;
using GT.JokeGenerator.Extensions;

namespace GT.JokeGenerator.Providers
{
    public class ConsoleInputProvider : IInputProvider
    {
        /// <summary>Reads the key.</summary>
        /// <returns>Entered key as character.</returns>
        public char ReadKey()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.Write(Environment.NewLine);
            return key.ToChar();
        }

        /// <summary>Reads the number.</summary>
        /// <returns>Entered key as number.</returns>
        public int ReadNumber()
        {
            return int.Parse(Console.ReadLine());
        }

        /// <summary>Reads the string.</summary>
        /// <returns>Entered key as string.</returns>
        public string ReadString()
        {
            return Console.ReadLine();
        }
    }
}
