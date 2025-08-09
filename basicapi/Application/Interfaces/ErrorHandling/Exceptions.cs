public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"{name} with key {key} was not found.") { }
}

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("One or more validation failures occurred.")
    {
        Errors = errors;
    }
}
