using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Converter;

public class PutRuleRequestConverter : JsonConverter<BaseRuleRequest>
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public PutRuleRequestConverter(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }
    
    public override BaseRuleRequest? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        var context = _httpContextAccessor.HttpContext;
        var ruleName = context?.Request.Path.Value?.Split('/')[^1];

        var readerClone = reader;

        using var jsonDocument = JsonDocument.ParseValue(ref readerClone);

        return ruleName switch
        {
            "CHECK_WITHDRAWAL_AMOUNT" => JsonSerializer.Deserialize<WithdrawalAmountRuleRequest>(ref reader, options),
            "CHECK_CUMULATIVE_AMOUNTS" => JsonSerializer.Deserialize<CumulativeAmountRuleRequest>(ref reader, options),
            "CHECK_TURNOVER" => JsonSerializer.Deserialize<TurnoverRuleRequest>(ref reader, options),
            _ => throw new NotSupportedException()
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BaseRuleRequest expression,
        JsonSerializerOptions options)
    {
    }
}