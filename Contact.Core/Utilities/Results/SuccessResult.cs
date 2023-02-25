namespace Contact.Core.Utilities.Results;

public class SuccessResult : Result
{
    public SuccessResult(string message)
        : base(true, message)
    {
    }
    
    public SuccessResult(List<string> messages)
        : base(true, messages)
    {
    }

    public SuccessResult()
        : base(true)
    {
    }
}