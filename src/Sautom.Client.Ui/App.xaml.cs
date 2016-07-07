using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Sautom.Client.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
	    static App()
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CreateSpecificCulture("ru-RU").IetfLanguageTag)));
        }

	    protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

	    private static void RunInDebugMode()
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }

	    private static void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            try
            {
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

	    private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

	    private static void HandleException(Exception ex)
        {
            if (ex == null) return;

            MessageBox.Show(Ui.Properties.Resources.Text_UnhandledException);
            Environment.Exit(1);
        }
    }
}
