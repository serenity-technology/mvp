namespace Share;

public class RuleBuilder
{
    #region Members
    private readonly List<IRule> _rules;
    private bool _evaluated = false;
    #endregion

    #region Constructor    
    public RuleBuilder()
    {
        _rules = [];
    }
    #endregion

    #region Public    
    public void AddRule(IRule rule)
    {
        _rules.Add(rule);
    }

    public bool IsValid
    {
        get
        {
            if (!_evaluated)
                throw new Exception("Rules not Evaluated");

            return !_rules.Any(w => w.IsValid == false);
        }
    }

    public List<Error> Errors
    {
        get
        {
            var errors = new List<Error>();

            foreach (var rule in _rules.Where(w => w.IsValid == false))
            {
                if (!(rule.Error is null))
                {
                    errors.Add(rule.Error);
                }
                else
                {
                    throw new Exception("InValid Rule must have a error");
                }
            }

            return errors;
        }
    }
        
    public async Task EvaluateAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            foreach (var rule in _rules)
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    await rule.EvaluateAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    rule.Error = new Error { Message = $"Rule [{rule.GetType().Name}] execution failed! [{exception.Message}]", Context = "Global.Exception" };
                }
            }
        }
        catch (Exception exception)
        {
            // We need to create dummy rule if something went wrong
            var rule = new ValidRuleBuilderRule { Message = exception.Message };
            AddRule(rule);
        }
        finally
        {
            _evaluated = true;
        }
    }
    #endregion
}