using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ConvertToUtf8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string Arg="";
        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args != null)
            {
                if (e.Args.Length > 0)
                {
                    for (int i = 0; i < e.Args.Length; i++)
                        Arg += e.Args[i];
                }
            }
        }
    }
}
