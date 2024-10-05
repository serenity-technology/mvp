namespace Share.Core.Test;

public class RulePass : Rule, IRule
{
    #region IRule    
    public Task EvaluateAsync(CancellationToken cancellationToken = default)
    {
        IsValid = true;

        return Task.CompletedTask;
    }
    #endregion
}