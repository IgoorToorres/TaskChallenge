namespace TaskChallenge.Application.Exceptions;

public sealed class ValidationException(IReadOnlyCollection<string> errors) : Exception
{
    public IReadOnlyCollection<string> Errors { get; } = errors;
}
