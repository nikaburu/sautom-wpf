using System;
using System.ServiceProcess;
using System.Threading;

namespace Sautom.Server
{
	class Program
	{
		static void Main(string[] args)
		{
			if (!Environment.UserInteractive)
			{
				ServiceBase.Run(new ServiceBase[] { new WindowsHostService() });
				return;
			}

			Console.WriteLine("Service Starting");
			Console.WriteLine("***********************************");

			using (Bootstrapper bootstrapper = new Bootstrapper())
			{
				bootstrapper.ConfigureApplication();
				bootstrapper.RunApplication();

				Console.WriteLine("Service Started:");
				Console.WriteLine("Press <Enter> to stop the service.");
				Console.ReadLine();

				Console.WriteLine("Service stopping....");
				Console.WriteLine("***********************************");
			}

			Thread.Sleep(1000);

			Console.WriteLine("Service stopped.");
			Console.WriteLine("***********************************");
		}
	}
}
