using GT.JokeGenerator.Models;
using System.Threading.Tasks;

namespace GT.JokeGenerator.Clients
{
    public interface IUserInfoClient
    {
        /// <summary>Gets the user information asynchronous.</summary>
        /// <returns>The user information.</returns>
        Task<UserInfo> GetUserInfoAsync();
    }
}
