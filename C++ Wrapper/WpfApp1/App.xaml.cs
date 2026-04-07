using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GraphApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        [STAThread]
        public static void Main()
        {
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
            //var mockDevice = new Mock<IDevice>();
            //mockDevice.Setup(d => d.DeviceId).Returns(100);
            //services.AddSingleton<IDevice>(mockDevice.Object);
            //services.AddSingleton<IMainViewModel, MainViewModel>();
            //services.AddSingleton<UserTestControl>();

            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            //var userTestControl = serviceProvider.GetService<UserTestControl>();
            var mainWindow = serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
