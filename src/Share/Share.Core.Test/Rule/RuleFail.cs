namespace Share.Core.Test;

public class RuleFail : Rule, IRule
{
    #region IRule    
    public Task EvaluateAsync(CancellationToken cancellationToken = default)
    {
        IsValid = false;
        return Task.CompletedTask;
    }
    #endregion
}