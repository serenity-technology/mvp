using TUnit.Assertions.Extensions.Throws;

namespace Share.Core.Test;

public class RulesEngineTest
{    
    [Test]
    public async Task Passed()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RulePass());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsTrue();
    }
    
    [Test]
    public async Task Failed()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RuleFail());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsFalse();
    }

    [Test]
    public async Task Exception()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RuleException());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsFalse();
    }
        
    [Test]
    public async Task MultiplePassed()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RulePass());
        ruleBuilder.AddRule(new RulePass());
        ruleBuilder.AddRule(new RulePass());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsTrue();
    }

    [Test]
    public async Task MultipleFailed()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RuleFail());
        ruleBuilder.AddRule(new RuleFail());
        ruleBuilder.AddRule(new RuleFail());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsFalse();
    }

    [Test]
    public async Task MultipleException()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RuleException());
        ruleBuilder.AddRule(new RuleException());
        ruleBuilder.AddRule(new RuleException());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsFalse();
    }

    [Test]
    public async Task Multiple()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RulePass());
        ruleBuilder.AddRule(new RuleFail());
        ruleBuilder.AddRule(new RuleException());
        await ruleBuilder.EvaluateAsync();

        await Assert.That(ruleBuilder.IsValid).IsFalse();
    }

    [Test]
    public async Task NotEvaluated()
    {
        var ruleBuilder = new RuleBuilder();
        ruleBuilder.AddRule(new RulePass());
        ruleBuilder.AddRule(new RuleFail());
        ruleBuilder.AddRule(new RuleException());

        await Assert.That(() =>
        {
            var isValid = ruleBuilder.IsValid;
        }).ThrowsException().OfType<Exception>();
    }
}