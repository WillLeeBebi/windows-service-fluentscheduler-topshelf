using System.Diagnostics;
using Topshelf;
using Topshelf.HostConfigurators;

namespace WinService.Core
{
    public class ServiceConfig
    {
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public HostConfigurator Settings { get; set; }

        private static void ConfigureService(ServiceConfig serviceConfig)
        {
            var serviceTitle = serviceConfig.ServiceTitle;
            serviceConfig.Settings.OnException(exception =>
            {
                var logMessage = $"{exception.Message} {exception.StackTrace}";
                Debug.WriteLine(logMessage);
            });
            serviceConfig.Settings.EnableServiceRecovery(config => { config.RestartService(1); });
            serviceConfig.Settings.StartAutomatically();
        }

        public static void StartService<T>(ServiceConfig serviceConfig) where T : new()
        {
            HostFactory.Run(config =>
            {
                config.Service<IWindowsService>(instance =>
                {
                    instance.ConstructUsing(() => (IWindowsService)new T());
                    instance.WhenStarted(service => { service.ServiceStarted(); });
                    instance.WhenPaused(service => { service.ServicePaused(); });
                    instance.WhenContinued(service => { service.ServiceContinued(); });
                    instance.WhenStopped(service => { service.ServiceStopped(); });
                });

                var serviceTitle = serviceConfig.ServiceTitle;
                var description = serviceConfig.ServiceDescription;

                config.SetServiceName(serviceTitle);
                config.SetDisplayName(serviceTitle);
                config.SetDescription(description);

                var settings = new ServiceConfig
                {
                    Settings = config,
                    ServiceTitle = serviceTitle,
                    ServiceDescription = description
                };
                ConfigureService(settings);
            });
        }
    }
}
