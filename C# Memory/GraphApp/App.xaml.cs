using GraphApp;
using GraphApp.Model;
using GraphApp.UserControls;
using GraphApp.ViewModel;
using GraphApp.ViewModel.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApp
{
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            ConsoleHelper.OpenConsole();
            Console.WriteLine("Console enabled");
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            Configure(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private readonly ServiceProvider serviceProvider;        

        private void Configure(ServiceCollection services)
        {
            //var mockDevice = new Mock<IDevice>); mockDevice.Setup(d => d.DeviceId).Returns(100); services.AddSingleton<IDevice>(mockDevice.Object);

            services.AddSingleton<IMainWindowModel, MainWindowModel>();

            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
