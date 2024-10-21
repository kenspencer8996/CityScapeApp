﻿using CityScapeApp.Objects.database;
using System.Runtime.CompilerServices;
namespace CityScapeApp.Objects
{
    public  class Logger
    {
        private static LoggingRepository loggingRepository;
        public Logger() 
        {
            loggingRepository = new LoggingRepository();
        }
        public static  void LogMessage(string message, [CallerMemberName] string memberName = "",
                             [CallerFilePath] string sourceFilePath = "")
        {
            try
            {
                LogEntity log = GetLog(message,0,memberName, sourceFilePath);
                loggingRepository.UpsertLogging(log);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void LogExceptionMessage(string message, Exception exception,
            [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            string exceptionmessage = "";
            if (exception == null)
            {
                exceptionmessage = exception.Message;
            }
            LogEntity log = GetLog(message, 0, memberName, sourceFilePath, exceptionmessage);
            loggingRepository.UpsertLogging(log);
        }
        public static void LogRuntime(decimal runtime, [CallerMemberName] string memberName = "",
                            [CallerFilePath] string sourceFilePath = "")
        {
            LogEntity log = GetLog("", runtime, memberName, sourceFilePath);
            loggingRepository.UpsertLogging(log);

        }
        private static LogEntity GetLog(string message, decimal runtime,
             string memberName,  string sourceFilePath, string exceptionmessage = "")
        {
            if (exceptionmessage == "")
            {
                message += "," + exceptionmessage;
            }
            string classname = System.IO.Path.GetFileNameWithoutExtension(sourceFilePath);
            LogEntity log = new LogEntity();
            log.Add(classname, runtime,  memberName, message);
            return log;
        }
       
    }
}
