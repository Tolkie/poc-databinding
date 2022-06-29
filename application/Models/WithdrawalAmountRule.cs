using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class WithdrawalAmountRule : BaseRule
{
    [JsonPropertyName("rule_name")]
    public string RuleName { get; set; } = "CHECK_WITHDRAWAL_AMOUNT";
    
    [JsonPropertyName("threshold")]
    public int Threshold { get; set; }
}