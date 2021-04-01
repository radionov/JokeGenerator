namespace GT.JokeGenerator.Providers
{
    public interface IInputProvider
    {
        /// <summary>Reads the key.</summary>
        /// <returns>Entered key as character.</returns>
        char ReadKey();

        /// <summary>Reads the number.</summary>
        /// <returns>Entered key as number.</returns>
        int ReadNumber();

        /// <summary>Reads the string.</summary>
        /// <returns>Entered key as string.</returns>
        string ReadString();
    }
}
