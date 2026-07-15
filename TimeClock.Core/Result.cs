namespace TimeClock.Core;

public readonly struct Result<T>
{
    public bool IsError { get; }
    public Error? Error { get; }
    public T? Value { get; }

    private Result(Error error)
    {
        IsError = true;
        Error = error;
        Value = default;
    }

    private Result(T value)
    {
        IsError = false;
        Error = default;
        Value = value;
    }

    public static implicit operator Result<T>(Error error) => new(error);
    public static implicit operator Result<T>(T value) => new(value);
}

public readonly struct Result
{
    public static Result Success => new(true);
    public static Result Failure => new(new Error());

    public bool IsError { get; }
    public Error? Error { get; }
    public bool? Value { get; }

    private Result(Error error)
    {
        IsError = true;
        Error = error;
        Value = default;
    }

    private Result(bool value)
    {
        IsError = false;
        Error = default;
        Value = value;
    }

    public static implicit operator Result(Error error) => new(error);
    public static implicit operator Result(bool value) => new(value);
}

public readonly struct Error(string? message = default)
{
    public string Message { get; } = message ?? string.Empty;
}
