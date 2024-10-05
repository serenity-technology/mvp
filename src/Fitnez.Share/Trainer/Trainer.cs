namespace Fitnez;

public record Trainer
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public Gender Gender { get; init; }
}