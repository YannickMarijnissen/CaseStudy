using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using wpf.Views;

namespace wpf.Viewmodels
{
    public class LoginViewmodel : BaseViewmodel
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; NotifyPropertyChanged(); }
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {

                case "Login": Login(); break;
            }
        }
        private void Login()
        {
            var vm = new TaskOverviewViewmodel();
            var view = new TaskOverviewView();
            view.DataContext = vm;
            view.Show();
        }
        public LoginViewmodel()
        {

        }
        public override string this[string columnName]
        {
            get
            {
            
                return "";
            }
        }
     
    }
}
