using Newtonsoft.Json;

namespace LazyLoadDataList.Data.Model
{
    /// <summary>
    /// Model class for Json data
    /// </summary>
    public class Rows
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imageHref")]
        public string ImageHref { get; set; }
    }
}