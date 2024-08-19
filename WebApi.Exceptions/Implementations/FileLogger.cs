using Microsoft.Extensions.Configuration;
using mMoser.Exceptions.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mMoser.Exceptions.Helpers;
using mMoser.Exceptions.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
//using mMoser.Domin.Models.VendorModel;

namespace mMoser.Exceptions.Implementations
{
    public class FileLogger : IErrorLogger
    {
        //private readonly mMoserExceptionDbContext _context;
        private readonly mMoserExceptionDbContext _context;
        public FileLogger(IConfiguration configuration, mMoserExceptionDbContext context)//
        {
            Configuration = configuration;
            _context = context;
        }
        public IConfiguration Configuration { get; }
        public void LogMessage(Exception ex)
        {
            DateTime p_created_at = DateTime.Now;
            string p_message = string.Empty;
            string p_inner_exception = string.Empty;

            if (ex.Message!=null)
            {
                p_message = ex.Message;
            }
            if (ex.InnerException != null)
            {
                p_inner_exception = ex.InnerException.ToString();
            }
            string p_stack_trace = ex.StackTrace;

            try
            {
                List<SpExceptionsDetals> RETURNVALE = _context.SpExceptionsDetals.FromSqlRaw("EXEC cms_sp_add_exception @p_message, @p_stack_trace,@p_inner_exception", new object[]{
                      new SqlParameter("@p_message", p_message),
                      new SqlParameter("@p_stack_trace", p_stack_trace),
                      new SqlParameter("@p_inner_exception", p_inner_exception)

            }).ToList();
            }
            catch (Exception EX)
            {
                throw;
            }
        
        }
        public void LogMessage(String msg)
        {
            ////put this in comman path 
            //string mainPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));
            //string folderPath = mainPath + "mMoser.Exceptions\\Log";
            //// put this one in fuction 
            //if (!(Directory.Exists(folderPath)))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}

            //FileStream objFileStrome = new FileStream(folderPath + "\\Msg_" + DateTime.Now.ToString("dd-mm-yyyy") + ".txt", FileMode.Append, FileAccess.Write);
            //StreamWriter objStreamWriter = new StreamWriter(objFileStrome);
            //objStreamWriter.Write("Message: " + msg);
            //objStreamWriter.Write(" Date/Time: " + DateTime.Now.ToString());
            //objStreamWriter.Write("============================================");
            //objStreamWriter.Close();
            //objFileStrome.Close();
        }

        //public void LogDebug(string message)
        //{
        //    logger.Debug(message);
        //}

        //public void LogError(string message)
        //{
        //    logger.Error(message);
        //}

        //public void LogInfo(string message)
        //{
        //    logger.Info(message);
        //}

        //public void LogWarn(string message)
        //{
        //    logger.Warn(message);
        //}
    }
}



//string mainPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));
//string folderPath = mainPath + "mMoser.Exceptions\\Log";
//if (!(Directory.Exists(folderPath)))
//{
//    Directory.CreateDirectory(folderPath);
//}
//FileStream objFileStrome = new FileStream(folderPath + "\\errlog_" + DateTime.Now.ToString("dd-mm-yyyy") + ".txt", FileMode.Append, FileAccess.Write);
//StreamWriter objStreamWriter = new StreamWriter(objFileStrome);
//objStreamWriter.Write("Message: " + ex.Message);
//objStreamWriter.Write("StackTrace: " + ex.StackTrace);
//objStreamWriter.Write("InnerException: " + ex.InnerException.Message);
//objStreamWriter.Write("Message: " + ex.Message.ToString());
//objStreamWriter.Write("Date/Time: " + DateTime.Now.ToString());
//objStreamWriter.Write("============================================");
//objStreamWriter.Close();



//objFileStrome.Close();
