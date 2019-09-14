using System.Diagnostics;
using FluentScheduler;

namespace WinService.Core
{
    public class ProcessService : IWindowsService
    {
        public void ServiceContinued()
        {
            Logger.Write("Service Continued");
        }

        public void ServicePaused()
        {
            Logger.Write("Service Paused");
        }

        public void ServiceStarted()
        {
            Logger.Write("Service Started");
            JobManager.Initialize(new ProcessRegistry());
        }

        public void ServiceStopped()
        {
            Logger.Write("Service Stopped");
        }
    }

    public class Logger
    {
        public static void Write(string message)
        {
            const string cs = "WindowsServiceLogger";
            if (!EventLog.SourceExists(cs))
                EventLog.CreateEventSource(cs, "Application");

            EventLog.WriteEntry(cs, message, EventLogEntryType.Error);
        }
    }
}
