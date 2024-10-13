using System.Text.Json.Serialization;

class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

class Feature
{
    public Properties Properties { get; set; }
}

class Properties
{
    [JsonPropertyName("mag")]
    public decimal mag { get; set; }

    [JsonPropertyName("place")]
    public string place { get; set; }

}