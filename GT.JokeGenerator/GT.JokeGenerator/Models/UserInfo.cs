using Newtonsoft.Json;

namespace GT.JokeGenerator.Models
{
    public class UserInfo : UserName
    {
        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        /// <summary>Gets or sets the region.</summary>
        /// <value>The region.</value>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}
