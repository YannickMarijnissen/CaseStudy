using dal;
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
            using (var context = new TaskManagerContext())
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Perform data seeding
                context.SeedData();
            }
            var vm = new LoginViewmodel();
            var view = new LoginView();
            view.DataContext = vm;
            view.Show();
        }
    }
}