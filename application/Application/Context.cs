using System.Runtime.InteropServices.ComTypes;
using WebApplication1.Models;

namespace application.Application;

public interface IStrategy
{
    void Execute(BaseRule rule);
}

class CumulativeAmountStrategy : IStrategy
{
    public void Execute(BaseRule rule)
    {
        // logic
        rule = (CumulativeAmountRule)rule;
    }
}

class TurnoverStrategy : IStrategy
{
    public void Execute(BaseRule rule)
    {
        // logic
        rule = (TurnoverRule)rule;
    }
}

class WithdrawalAmountStrategy : IStrategy
{
    public void Execute(BaseRule rule)
    {
        // logic
        rule = (WithdrawalAmountRule)rule;
    }
}

public class UpdateRuleUseCase : IUpdateRuleUseCase
{

    IStrategy _updateRule = null;

    public void UpdateRule(BaseRule rule)
    {
        _updateRule = GetUpdater(rule);
        _updateRule.Execute(rule);
    }

    private IStrategy GetUpdater(BaseRule rule)
    {
        switch (rule)
        {
            case CumulativeAmountRule:
                return new CumulativeAmountStrategy();
            case TurnoverRule:
                return new TurnoverStrategy();
            case WithdrawalAmountRule:
                return new WithdrawalAmountStrategy();
            default:
                // TODO find better exception
                throw new HttpRequestException();
        }
    }

}

public interface IUpdateRuleUseCase
{
    void UpdateRule(BaseRule rule);
}
