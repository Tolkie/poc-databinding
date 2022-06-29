using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Converter;

public class PutRuleRequestConverter : JsonConverter<BaseRule>
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public PutRuleRequestConverter(IHttpContextAccessor httpContextAccessor)
    {
        this._httpContextAccessor = httpContextAccessor;
    }
    
    public override BaseRule? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        var context = _httpContextAccessor.HttpContext;
        var ruleName = context?.Request.Path.Value?.Split('/')[^1];

        var readerClone = reader;

        using var jsonDocument = JsonDocument.ParseValue(ref readerClone);

        return ruleName switch
        {
            "CHECK_WITHDRAWAL_AMOUNT" => JsonSerializer.Deserialize<WithdrawalAmountRule>(ref reader, options),
            "CHECK_CUMULATIVE_AMOUNTS" => JsonSerializer.Deserialize<CumulativeAmountRule>(ref reader, options),
            "CHECK_TURNOVER" => JsonSerializer.Deserialize<TurnoverRule>(ref reader, options),
            _ => throw new NotSupportedException()
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BaseRule expression,
        JsonSerializerOptions options)
    {
    }
}