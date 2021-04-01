using Newtonsoft.Json;

namespace GT.JokeGenerator.Models
{
    public class UserName
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>Gets or sets the surname.</summary>
        /// <value>The surname.</value>
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
    }
}
