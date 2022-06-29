using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class BaseRuleRequest
{
    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }
    
    [JsonPropertyName("regulation")]
    public string Regulation { get; set; }
}