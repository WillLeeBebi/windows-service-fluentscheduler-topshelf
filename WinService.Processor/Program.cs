using WinService.Core;

namespace WinService.Processor
{
    internal static class Program
    {
        private static void Main()
        {
            var serviceConfig = new ServiceConfig
            {
                ServiceTitle = "Data Processor Windows Service",
                ServiceDescription = "This Is a Windows Service Description"
            };
            ServiceConfig.StartService<ProcessService>(serviceConfig);
        }
    }
}
