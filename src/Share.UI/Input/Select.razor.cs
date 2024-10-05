namespace Share;

public partial class Select<TValue> : Input
{
    #region Members
    [CascadingParameter(Name = "form")] private Form InputForm { get; set; } = default!;
    #endregion

    #region Public
    [Parameter] public TValue Value { get; set; } = default!;
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
    [Parameter] public IEnumerable<IOption<TValue>> Options { get; set; } = default!;
    #endregion

    #region Private
    private string StringValue
    {
        get { return GetValue(); }
        set { SetValue(value); }
    }

    private string GetValue()
    {
        if (Value != null)
        {
            return Value.ToString()!;
        }
        else
        {
            return string.Empty;
        }
    }

    private void SetValue(string value)
    {
        var underlyingType = Nullable.GetUnderlyingType(typeof(TValue));
        if (underlyingType != null && value != null)
        {
            Value = default!;
        }
        else
        {
            switch (typeof(TValue))
            {
                case var _ when typeof(TValue) == typeof(string):
                    Value = (TValue)(object)value!;
                    break;
                case var _ when typeof(TValue).IsEnum:
                    if (Enum.TryParse(typeof(TValue), value, out var enumValue))
                        Value = (TValue)(object)enumValue!;
                    else
                        Value = default!;
                    break;
                case var _ when typeof(TValue) == typeof(int):
                    if (int.TryParse(value, out var number))
                        Value = (TValue)(object)number;
                    else
                        Value = default!;
                    break;
                case var _ when typeof(TValue) == typeof(Guid):
                    if (Guid.TryParse(value, out var guid))
                        Value = (TValue)(object)guid;
                    else
                        Value = default!;
                    break;
                default:
                    Value = default!;
                    break;
            }
        }

        _ = ValueChanged.InvokeAsync(Value);
    }

    private void OnValueChange(ChangeEventArgs e)
    {
        var value = e.Value?.ToString() ?? "";
        SetValue(value);
    }

    private string LabelText()
    {
        //if (Optional) return $"{Label} - Optional";
        //else return Label;

        return Label;
    }
    #endregion

    #region Protected
    protected override void OnInitialized()
    {
        InputForm?.AddInput(this);
    }
    #endregion
}