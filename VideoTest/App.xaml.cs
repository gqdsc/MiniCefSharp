using System;
using System.Windows;

namespace VideoTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            BrowserInitializer.Initialize();
        }

        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += BrowserInitializer.Resolver;
        }
    }
}
