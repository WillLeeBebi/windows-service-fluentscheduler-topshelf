using System.Diagnostics;

namespace WinService.Core
{
    public class WindowsService : IWindowsService
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
            string cs = "WindowsServiceLogger";
            if (!EventLog.SourceExists(cs))
                EventLog.CreateEventSource(cs, "Application");

            EventLog.WriteEntry(cs, message, EventLogEntryType.Error);
        }
    }
}
