namespace WinService.Core
{
    interface IWindowsService
    {
        void ServiceStarted();
        void ServicePaused();
        void ServiceContinued();
        void ServiceStopped();
    }
}
