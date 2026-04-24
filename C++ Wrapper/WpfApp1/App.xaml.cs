using GraphApp;
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
using GraphApp.ViewModel;
using GraphApp.ViewModel.Abstract;
using GraphApp.CustomControls;

namespace GraphApp
{
    public partial class App : Application
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [STAThread]
        public static void Main()
        {
            // Allocate a console for this WPF process
            var _ = AllocConsole();

            // Redirect Console.Out to the new console
            var stdHandle = Console.OpenStandardOutput();
            var writer = new StreamWriter(stdHandle, Encoding.UTF8) { AutoFlush = true };
            Console.SetOut(writer);
            Console.SetError(writer); // optional: redirect Console.Error too

            Console.WriteLine("Console initialized from WPF App.Main");
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }

        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            Configure(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void Configure(ServiceCollection services)
        {
            //var mockDevice = new Mock<IDevice>);
            //mockDevice.Setup(d => d.DeviceId).Returns(100);
            //services.AddSingleton<IDevice>(mockDevice.Object);

            services.AddSingleton<IMainWindowModel, MainWindowModel>();
            
            services.AddSingleton<UserTestControl2>();

            services.AddSingleton<UserTestControl3>();

            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var userTestControl3 = serviceProvider.GetService<UserTestControl3>();
            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
