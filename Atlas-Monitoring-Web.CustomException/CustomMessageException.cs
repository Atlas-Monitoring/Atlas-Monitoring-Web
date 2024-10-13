namespace Atlas_Monitoring_Web.CustomException
{
    public class CustomMessageException : Exception
    {
        public CustomMessageException(string? message) : base(message)
        {
        }
    }
}
