using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Krasnodar_Resorts_Gizetdinov.Pages;


namespace Krasnodar_Resorts_Gizetdinov
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
           
            SplashScreen splashScreen = new SplashScreen("/Pages/Res/Icons/LogoKurort.png");
            splashScreen.Show(false);
            splashScreen.Close(new TimeSpan(0, 0, 3));
            base.OnStartup(e);
            Task.Factory.StartNew(() =>
            {
                
                System.Threading.Thread.Sleep(3000);

              
                this.Dispatcher.Invoke(() =>
                {
                    var mainWindow = new RegWindow();
                    this.MainWindow = mainWindow;
                    mainWindow.Show();
                });
            });
        }
    }
}
