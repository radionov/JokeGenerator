using System;

namespace GT.JokeGenerator.Extensions
{
    public static class ConsoleKeyExtension
    {
        /// <summary>Converts to char.</summary>
        /// <param name="consoleKeyInfo">The console key information.</param>
        /// <returns>Entered key as character.</returns>
        public static char ToChar(this ConsoleKeyInfo consoleKeyInfo)
        {
            char key;
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
                case ConsoleKey.N:
                    key = 'n';
                    break;
                default:
                    key = 'q';
                    break;
            }

            return key;
        }
    }
}
