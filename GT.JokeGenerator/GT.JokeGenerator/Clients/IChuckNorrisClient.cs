using GT.JokeGenerator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT.JokeGenerator.Clients
{
    public interface IChuckNorrisClient
    {
        /// <summary>Gets the categories asynchronous.</summary>
        /// <returns>The categories.</returns>
        Task<IEnumerable<string>> GetCategoriesAsync();

        /// <summary>Gets the randon joke asynchronous.</summary>
        /// <returns>The joke.</returns>
        Task<Joke> GetRandonJokeAsync();

        /// <summary>Gets the joke by category name asynchronous.</summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns>The joke.</returns>
        /// <exception cref="ArgumentNullException">categoryName</exception>
        Task<Joke> GetJokeByCategoryNameAsync(string categoryName);
    }
}
