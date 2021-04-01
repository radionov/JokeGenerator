using System;
using System.Globalization;

namespace GT.JokeGenerator.Providers
{
    public class ConsoleOutputProvider : IOutputProvider
    {
        /// <summary>Writes the specified value.</summary>
        /// <param name="value">The value.</param>
        public void Write(string value)
        {
            Console.WriteLine(value);
        }

        /// <summary>Writes the format.</summary>
        /// <param name="format">The format.</param>
        /// <param name="values">The values.</param>
        public void WriteFormat(string format, params object[] values)
        {
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, format, values));
        }
    }
}
