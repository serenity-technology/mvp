namespace Share.Core.Test;

public class RuleException : Rule, IRule
{
    #region IRule    
    public Task EvaluateAsync(CancellationToken cancellationToken = default)
    {
        throw new Exception("rule exception");
    }
    #endregion
}