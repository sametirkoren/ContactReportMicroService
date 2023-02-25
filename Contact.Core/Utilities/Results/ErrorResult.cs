namespace Contact.Core.Utilities.Results;

public class ErrorResult : Result
{
    public ErrorResult(string message)
        : base(false, message)
    {
    }
    public ErrorResult(List<string> messages)
        : base(false, messages)
    {
    }

    public ErrorResult()
        : base(false)
    {
    }
}