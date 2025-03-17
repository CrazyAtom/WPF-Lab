using System.Windows;
using WpfTestApp.Views;

namespace WpfTestApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        MainWindow main = new();
        MainWindow.ShowDialog();
    }
}

