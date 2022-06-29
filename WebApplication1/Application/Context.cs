using WebApplication1.Models;

namespace WebApplication1.Application;

public interface IStrategy
{
    public void Execute();
}

class StrategyA : IStrategy
{
    public void Execute()
    {
        
    }
}
class StrategyB : IStrategy
{
    public void Execute()
    {
        
    }
}

public class Context
{
    private IStrategy _strategy = new StrategyA();


    public void demo(BaseRule rule)
    {
        Console.WriteLine(rule.GetType());
    }
    
    
    public void execute()
    {
        _strategy.Execute();
    }

    public void setStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }
}