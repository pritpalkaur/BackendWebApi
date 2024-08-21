using WebApi.Exceptions;
using WebApi.Exceptions.Data;
using WebApi.Exceptions.Service;
using Microsoft.Extensions.Logging;

namespace WebApi.Exceptions.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;
        private readonly LoggingDbContext _context;
        public LoggingService(LoggingDbContext context, ILogger<LoggingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void LogInformation(Exception ex)
        {
            _logger.LogInformation(ex.Message.ToString());
        }
        public async Task LogExceptionAsync(Exception exception)
        {
            try
            {
                // Check if there is an inner exception
                if (exception.InnerException != null)
                {
                    var innerException = exception.InnerException;

                    var innerLog = new ExceptionLog
                    {
                        Timestamp = DateTime.UtcNow,
                        Message = innerException.Message,
                        StackTrace = innerException.StackTrace,
                        Source = innerException.Source
                    };

                    _context.ExceptionLogs.Add(innerLog);
                }
                else
                {
                    // Log the outer exception first
                    var log = new ExceptionLog
                    {
                        Timestamp = DateTime.UtcNow,
                        Message = exception.Message,
                        StackTrace = exception.StackTrace,
                        Source = exception.Source
                    };

                    _context.ExceptionLogs.Add(log);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                LogInformation(ex); // Log the exception that occurred during logging
            }
        }


    }
}
//public class LoggingService : ILoggingService
//    {
//        private readonly LoggingDbContext _context;
//        private readonly ILogger _logger;
//        public LoggingService(LoggingDbContext context, ILogger logger)
//        {
//            _context = context;
//            _logger = logger;
//        }

//        public async Task LogExceptionAsync(Exception exception)
//        {

//            var log = new ExceptionLog
//            {
//                Timestamp = DateTime.UtcNow,
//                Message = exception.Message,
//                StackTrace = exception.StackTrace,
//                Source = exception.Source
//            };
            
//            _context.ExceptionLogs.Add(log);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
