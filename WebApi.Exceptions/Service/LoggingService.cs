using WebApi.Exceptions;
using WebApi.Exceptions.Data;
using WebApi.Exceptions.Service;
using Microsoft.Extensions.Logging;

namespace WebApi.Exceptions.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        // Other logging methods...
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
