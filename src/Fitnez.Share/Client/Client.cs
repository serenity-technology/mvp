namespace Fitnez;

public record Client
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;    
    public Gender Gender { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public string IdPassport { get; init; } = default!;
    public string Address { get; init; } = default!;    
}