using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelicitySecurity.Core.Utils
{
    /// <summary>
    /// The category in which the error should be logged. 
    /// </summary>
    public enum LogLevel
    {
        Information, 
        Detail, 
        Warning, 
        Error, 
        Debug
    }

    /// <summary>
    /// Handles the logging of any error exceptions that occur within the Felicity Security application. 
    /// </summary>
    public class Logging
    {
        private static EventLogEntryType eventType;

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        private static void LogEvent(string action, string message, LogLevel loglevel)
        {
            string sectionName = string.Format("Logging/{0}", loglevel.ToString());
            string source = sectionName + "Source" + "Felicity Security";
            string logName = sectionName + "LogName" + "Application";
            string eventText = string.Format("{0} ({1}): {2}", action, loglevel, message);
         
            if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, logName);
                }
               
            switch(loglevel)
            {
                case LogLevel.Error:
                    eventType = EventLogEntryType.Error;
                    break;
                case LogLevel.Warning:
                    eventType = EventLogEntryType.Warning;
                    break;
                case LogLevel.Information:
                    eventType = EventLogEntryType.Information;
                    break;
                case LogLevel.Detail:
                    break;

            }
            EventLog.WriteEntry(source, eventText, eventType);
        }

        /// <summary>
        /// Logs the error event 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="e"></param>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public static void LogErrorEvent(string action, Exception e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if(e != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Source:");
                if(e.Source != null)
                {
                    if(e.TargetSite != null)
                    {
                        stringBuilder.AppendLine(string.Format("{0} ({1})", e.TargetSite.Name, e.Source));
                    }
                    else
                    {
                        stringBuilder.AppendLine(e.Source);
                    }
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Exception:");
                stringBuilder.AppendLine(e.GetType().Name);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("Message:");
                if(e.Message != null)
                {
                    stringBuilder.AppendLine(e.Message);
                }
                Exception innerException = e.InnerException;
                while(innerException != null)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine("Inner Exception:");
                    stringBuilder.AppendLine(innerException.GetType().Name);
                    
                    stringBuilder.AppendLine("Message:");
                    stringBuilder.AppendLine(innerException.Message);
                    innerException = innerException.InnerException;
                }
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("StackTrace:");
                if(e.StackTrace != null)
                {
                    stringBuilder.AppendLine(e.StackTrace);
                }
            }
            LogEvent(action, stringBuilder.ToString(), LogLevel.Error);
        }

        public static void LogErrorEvent(object obj, Exception e)
        {
            LogErrorEvent(obj == null ? "" : obj.GetType().Name, e);
        }
    }
}
