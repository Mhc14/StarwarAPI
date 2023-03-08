using Newtonsoft.Json;

namespace SWAPI.Models
{
    public class ResponseSW
    {
        public List<Swpublic>? results { get; set; }
    }
    public class Swpublic
    {
        public string? Name { get; set; }
        public string? Height { get; set; }
        public string? Mass { get; set; }
        public string? Gender { get; set; }
    }

    public class ResponseDownload
    {
        public List<SwProtected>? results { get; set; }
    }
    public class SwProtected : Swpublic
    {
        [JsonProperty("Hair_color")]
        public string? Haircolor { get; set; }

        [JsonProperty("Skin_color")]
        public string? Skincolor { get; set; }

        [JsonProperty("Eye_color")]
        public string? Eyecolor { get; set; }

        [JsonProperty("Birth_year")]
        public string? Birthyear { get; set; }

    }
}
