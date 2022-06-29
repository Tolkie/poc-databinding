using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class TurnoverRule : BaseRule
{
    [JsonPropertyName("rule_name")]
    public string RuleName { get; set; } = "CHECK_TURNOVER";
    
    [JsonPropertyName("bet_rate")]
    public decimal BetRate { get; set; }
    
    [JsonPropertyName("period_hours")]
    public int PeriodHours { get; set; }
    
    [JsonPropertyName("deposited_amount_min")]
    public int DepositedAmountMin { get; set; }
    
    [JsonPropertyName("withdrawn_amount_min")]
    public int WithdrawnAmountMin { get; set; }
}