using System;
using System.ServiceProcess;
using System.Threading;

namespace Sautom.Server
{
    public sealed class WindowsHostService : ServiceBase
    {
		private Bootstrapper Bootstrapper { get; set; }

	    internal WindowsHostService()
        {
			Bootstrapper = new Bootstrapper();
			ServiceName = "SautomServerWcfHost";
        }

	    protected override void OnStart(string[] args)
        {
			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Service Starting...");
			Console.WriteLine("***********************************");

			Bootstrapper
				.ConfigureApplication()
				.RunApplication();
        }

		protected override void OnStop()
		{
			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Service stopping...");
			Console.WriteLine("***********************************");

			Bootstrapper.Dispose();
			Thread.Sleep(1000);

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Service stopped.");
			Console.WriteLine("***********************************");
		}

		protected override void OnShutdown()
		{
			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Service stopping due to shutdown...");
			Console.WriteLine("***********************************");

			Bootstrapper.Dispose();
			Thread.Sleep(1000);

			Console.WriteLine(Environment.NewLine);
			Console.WriteLine("Service stopped due to shutdown.");
			Console.WriteLine("***********************************");
		}
	}
}