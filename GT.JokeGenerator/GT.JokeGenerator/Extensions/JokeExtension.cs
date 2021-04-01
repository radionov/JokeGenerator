using GT.JokeGenerator.Models;
using System;

namespace GT.JokeGenerator.Extensions
{
    public static class JokeExtension
    {
        private const string Chuck = "Chuck";
        private const string Norris = "Norris";

        /// <summary>Replaces the with.</summary>
        /// <param name="joke">The joke.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns>The joke with replaced name and surname.</returns>
        /// <exception cref="ArgumentNullException">joke
        /// or
        /// userName</exception>
        public static Joke ReplaceWith(this Joke joke, UserName userName)
        {
            if(joke == null)
            {
                throw new ArgumentNullException(nameof(joke));
            }

            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            joke.Value = joke.Value.Replace(Chuck, userName.Name);
            joke.Value = joke.Value.Replace(Norris, userName.Surname);

            return joke;
        }
    }
}
