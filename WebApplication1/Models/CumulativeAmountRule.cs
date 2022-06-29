using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class CumulativeAmountRule : BaseRule
{
    [JsonPropertyName("rule_name")]
    public string RuleName { get; set; } = "CHECK_CUMULATIVE_AMOUNTS";
    
    [JsonPropertyName("threshold")]
    public int Threshold { get; set; }
}