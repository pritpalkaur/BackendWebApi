using WebApi.Exceptions.Service;
using WebApi.Exceptions.Data;

namespace WebApi.Exceptions.Service
{
    public interface ILoggingService
    {
        public void LogInformation(Exception ex);
        Task LogExceptionAsync(Exception exception);
    }
}
