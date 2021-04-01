using GT.JokeGenerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace GT.JokeGenerator.Clients
{
    public class ChuckNorrisClient : IChuckNorrisClient
    {
        private const string BaseUri = "https://api.chucknorris.io";

        private HttpClient Client { get; }

        /// <summary>Initializes a new instance of the <see cref="ChuckNorrisClient" /> class.</summary>
        public ChuckNorrisClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseUri);
        }

        /// <summary>Gets the categories asynchronous.</summary>
        /// <returns>The categories.</returns>
        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            string url = "jokes/categories";
            var json = await Client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<string>>(json);
        }

        /// <summary>Gets the randon joke asynchronous.</summary>
        /// <returns>The joke.</returns>
        public async Task<Joke> GetRandonJokeAsync()
        {
            string url = "jokes/random";
            var json = await Client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Joke>(json);
        }

        /// <summary>Gets the joke by category name asynchronous.</summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns>The joke.</returns>
        /// <exception cref="ArgumentNullException">categoryName</exception>
        public async Task<Joke> GetJokeByCategoryNameAsync(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException(nameof(categoryName));
            }

            string url = string.Format(CultureInfo.InvariantCulture, "jokes/random?category={0}", categoryName);
            var json = await Client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Joke>(json);
        }
    }
}
