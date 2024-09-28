namespace Atlas_Monitoring_Web.CustomException
{
    public class CustomWebException : Exception
    {
        public CustomWebException(string? message) : base(message)
        {
        }
    }
}
