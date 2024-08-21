namespace WebApi.Interface
{
    public interface IErrorLogger
    {
        void LogMessage(Exception ex);
    }
}
