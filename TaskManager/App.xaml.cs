using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf.Viewmodels;
using wpf.Views;

namespace wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var vm = new TaskOverviewViewmodel();
            var view = new CalendarView();
            view.DataContext = vm;
            view.Show();
        }
    }
}