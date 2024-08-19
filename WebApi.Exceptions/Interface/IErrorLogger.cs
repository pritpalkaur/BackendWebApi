using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mMoser.Exceptions.Interface
{
    public interface IErrorLogger
    {
        void LogMessage(Exception ex);
        void LogMessage(string ex);
        //void LogInfo(string message);
        //void LogWarn(string message);
        //void LogDebug(string message);
        //void LogError(string message);
    }
}
