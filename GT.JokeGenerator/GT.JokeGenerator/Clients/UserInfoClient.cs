using GT.JokeGenerator.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GT.JokeGenerator.Clients
{
    public class UserInfoClient : IUserInfoClient
    {
        private const string BaseUri = "https://www.names.privserv.com/api/";

        private HttpClient Client { get; }

        /// <summary>Initializes a new instance of the <see cref="UserInfoClient" /> class.</summary>
        public UserInfoClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseUri);
        }

        /// <summary>Gets the user information asynchronous.</summary>
        /// <returns>The user information.</returns>
        public async Task<UserInfo> GetUserInfoAsync()
        {
            var json = await Client.GetStringAsync("");
            return JsonConvert.DeserializeObject<UserInfo>(json);
        }
    }
}
