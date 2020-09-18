using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            new LiteEntity.LiteDB().Database.EnsureCreated();
            //CreateHostBuilder(new string[0]).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        //.ConfigureWebHostDefaults(webBuilder =>
        //{
        //    webBuilder.UseUrls("http://0.0.0.0:8000", "https://0.0.0.0:8001").UseStartup<Startup>();
        //});
    }
}
