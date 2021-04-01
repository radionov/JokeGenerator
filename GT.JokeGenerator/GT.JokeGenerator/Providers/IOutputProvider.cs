namespace GT.JokeGenerator.Providers
{
    public interface IOutputProvider
    {
        /// <summary>Writes the specified value.</summary>
        /// <param name="value">The value.</param>
        void Write(string value);

        /// <summary>Writes the format.</summary>
        /// <param name="format">The format.</param>
        /// <param name="values">The values.</param>
        void WriteFormat(string format, params object[] values);
    }
}
