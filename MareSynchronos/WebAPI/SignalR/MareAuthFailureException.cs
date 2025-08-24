namespace ARPSynchronos.WebAPI.SignalR;

public class ARPAuthFailureException : Exception
{
    public ARPAuthFailureException(string reason)
    {
        Reason = reason;
    }

    public string Reason { get; }
}