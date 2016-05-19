using Newtonsoft.Json;

namespace LazyLoadDataList.Data.Model
{
    /// <summary>
    /// Model class for the Json datass
    /// </summary>
    public class Facts
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rows")]
        public Rows[] Rows { get; set; }
    }
}