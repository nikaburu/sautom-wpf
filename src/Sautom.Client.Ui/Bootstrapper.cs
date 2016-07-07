using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using Microsoft.Windows.Controls.Ribbon;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sautom.Client.Ui.Utils;

namespace Sautom.Client.Ui
{
    internal class Bootstrapper : UnityBootstrapper
    {
	    public Bootstrapper()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU");
        }

	    protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = Prism.Modularity.ModuleCatalog.CreateFromXaml(
                        new Uri("/Sautom.Client.Ui;component/ModuleCatalog.xaml", UriKind.Relative));

            return catalog;
        }

	    protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            Views.MainWindow view = Container.TryResolve<Views.MainWindow>();

            // Display the shell's root visual.
            view.Show();

            return view;
        }

	    protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            // Call base method
            var mappings = base.ConfigureRegionAdapterMappings();
            if (mappings == null) return null;

            // Add custom mappings
            mappings.RegisterMapping(typeof(Ribbon), Container.TryResolve<RibbonRegionAdapter>());

            // Set return value
            return mappings;
        }
    }
}
