using WebApi.Exceptions.Service;
using WebApi.Exceptions.Data;

namespace WebApi.Exceptions.Service
{
    public interface ILoggingService
    {
        public void LogInformation(string message);
        //Task LogExceptionAsync(Exception exception);
    }
}
