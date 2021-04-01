using Newtonsoft.Json;
using System;

namespace GT.JokeGenerator.Models
{
    public class Joke
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>Gets or sets the URL.</summary>
        /// <value>The URL.</value>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>Gets or sets the icon URL.</summary>
        /// <value>The icon URL.</value>
        [JsonProperty(PropertyName = "icon_url")]
        public string IconUrl { get; set; }

        /// <summary>Gets or sets the created.</summary>
        /// <value>The created.</value>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime Created { get; set; }

        /// <summary>Gets or sets the updated.</summary>
        /// <value>The updated.</value>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime Updated { get; set; }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>Gets or sets the categories.</summary>
        /// <value>The categories.</value>
        [JsonProperty(PropertyName = "categories")]
        public string[] Categories { get; set; }
    }
}
