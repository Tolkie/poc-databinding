using WebApplication1.Models;

namespace WebApplication1.Converter;

public static class PutRuleConverter
{
    public static BaseRule Convert(BaseRuleRequest rule)
    {
        return rule switch
        {
            CumulativeAmountRuleRequest tmp => new CumulativeAmountRule(),
            TurnoverRuleRequest tmp => new TurnoverRule(),
            WithdrawalAmountRuleRequest tmp => new WithdrawalAmountRule(),
            _ => new BaseRule()
        };
    }
}
