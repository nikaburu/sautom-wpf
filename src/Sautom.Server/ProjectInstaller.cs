using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Sautom.Server
{
    // Provide the ProjectInstaller class which allows 
    // the service to be installed by the Installutil.exe tool
    [RunInstaller(true)]
    public sealed class ProjectInstaller : Installer
    {
	    public ProjectInstaller()
        {
		    ServiceProcessInstaller process = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};
		    ServiceInstaller service = new ServiceInstaller {ServiceName = "WCFWindowsHostService"};

		    Installers.Add(process);
            Installers.Add(service);
        }
    }
}