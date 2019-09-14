using FluentScheduler;

namespace WinService.Core
{
    public class ProcessRegistry : Registry
    {
        public ProcessRegistry()
        {
            Schedule<ProcessJob>().ToRunNow()
                .AndEvery(3).Seconds();
        }
    }
}
