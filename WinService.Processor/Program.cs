namespace WinService.Processor
{
    internal class Program
    {
        private static void Main()
        {
            var serviceConfig = new ServiceConfig
            {
                ServiceTitle = "GeoMongo Consumer",
                ServiceDescription = "GeoMongo Consumer for non-Uavt Addresses"
            };
            ServiceConfig.StartService<WindowsService>(serviceConfig);
        }
    }
}
