using System;
using System.Linq;
using System.Windows;
using dal;
using models;
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
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; NotifyPropertyChanged(); }
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
            using (var context = new TaskManagerContext())
            {
                // Check if there is a user with the entered username and password
                var user = context.Users.SingleOrDefault(u => u.Username == Username && u.Password == Password);

                if (user != null)
                {
                    UserId = user.Id;
                  
                    var vm = new TaskOverviewViewmodel(UserId); // Pass the UserId
                    var view = new TaskOverviewView();
                    view.DataContext = vm;
                    view.Show();
                }
                else
                {
                    // Authentication failed
                    MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
