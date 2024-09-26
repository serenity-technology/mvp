namespace Share;

public partial class Page
{
    #region Public
    [Parameter] public string Title { get; set; } = default!;
    [Parameter] public string Label { get; set; } = default!;
    [Parameter] public RenderFragment Body { get; set; } = default!;
    [Parameter] public RenderFragment ActionBar { get; set; } = default!;
    #endregion    
}